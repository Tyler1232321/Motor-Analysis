// An Application for Recieving data from an Arduino, transforming the data, saving the peaks into a table, and plotting the individual peak's aplitude over time.
// Author: John Tyler Beckingham

/* TODO:
 * - Select a lower Baud Rate
 * - Make shit the same size and look nice
 * - Make the Legend reset at the reset button click
 * - Add a title for the axis of the FFT Graph
 * - Add a title for the axis of the THree dim chart
 * - Change the title of the columns 
 * */

// A region for adding namesapces to the project
#region Adding Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Numerics;
using Accord.Audio.Filters;
#endregion

namespace FFT_Analysis
{
    public partial class Form1 : Form
    {
        // Initializing variables
        #region Initializing variables
        double Tolerance = 2;
        Stopwatch SW; // the stopwatch
        Stopwatch timeout;
        List<double> Y = new List<double>(); // stores X time data
        List<double> X = new List<double>(); // stores Y time data
        string input; // gets arduino input
        string name = ""; // name of the series we are labeling
        double data; // stores the data from arduino
        double counter = 0; // counts stuff
        double MIN;
        StreamWriter Writer; // writes stuff
        bool GettingData; // States whether data is currently being collected
        int count = 0; // counts more stuff
        StreamReader Reader; // reads files
        string[] lines; // splits the input from the arduino
        double time; // gets the time from the stopwatch
        string filename; // stores the filename
        FFTData FFT; // stores FFT data
        string TimeStamp; // gets the current timestamp for file saving
        string TimeString; // stores the string and useable version of the timestamp
        List<List<Tuple<double, double>>> PeakList = new List<List<Tuple<double, double>>>(); // The variable that stores the peak list
        string directory; // directory for saving FFT data
        bool Arduino; // whether the arduino is currently communicating with the app
        DateTime start; // the start time of the data collection
        DateTime end; // the time of the most recent batch of data that was collected
        Dictionary<Double, Double> PeakSeries = new Dictionary<Double, Double>(); // the dictionary to help with producing the peak chart
        bool STOP = false; // variable that stops the data collection
        bool PlaceLabel = false; // a boolean value describing whether we are currently placing a label
        bool StartFreqSelect = false;
        bool EndFreqSelect = false;
        bool Update = true;
        List<Label> LabelList = new List<Label>(); // list of labels for chart legend
        List<TextBox> TextBoxList = new List<TextBox>(); // list of textboxes for chart legend
        List<Button> SetButtonList = new List<Button>(); // list of buttons for setting chart legend
        double last = 0; // set base value for last
        double mul = 1; // set base value for the base time multiple for constant time setting data gathering
        int NumData = 5000; // set the default number of data points per analysis
        int NumMinutes = 22; // set the default number of minutes of data collection
        int loop;
        int pointsToPlot = 500; // set the default number of points to plot
        List<Double> newX = new List<double>(); // initialize the reduced list for fft X data
        List<Double> newY = new List<double>(); // initialize the reduced list for fft Y data
        double StartFreq = 0;
        double EndFreq = 125;
        CancellationTokenSource cts;
        bool notRecieved = true;
        bool dispWar = true;
        #endregion

        // Form Setup
        public Form1()
        {
            InitializeComponent();
            string[] portNames = SerialPort.GetPortNames(); // Get Port names
            StopCollectingButton.Enabled = false;
            foreach (string name in portNames) // Add the port names to the port selection comboBox
            {
                comboBox1.Items.Add(name);
            }
            if (portNames.Length == 0) // Send no serial port available if no port detected
            {
                MessageBox.Show("No Serial Port Avaliable");
            }
            // Gets a list of the labels used to create the custom legend
            LabelList.Add(LegendLabel1);
            LabelList.Add(LegendLabel2);
            LabelList.Add(LegendLabel3);
            LabelList.Add(LegendLabel4);
            LabelList.Add(LegendLabel5);
            LabelList.Add(LegendLabel6);
            LabelList.Add(LegendLabel7);
            // Gets a list of the text boxes used to create a custom legend
            TextBoxList.Add(LegendTextBox1);
            TextBoxList.Add(LegendTextBox2);
            TextBoxList.Add(LegendTextBox3);
            TextBoxList.Add(LegendTextBox4);
            TextBoxList.Add(LegendTextBox5);
            TextBoxList.Add(LegendTextBox6);
            TextBoxList.Add(LegendTextBox7);
            // gets a list of the Set Buttons used to create a custom Legend
            SetButtonList.Add(SetButton1);
            SetButtonList.Add(SetButton2);
            SetButtonList.Add(SetButton3);
            SetButtonList.Add(SetButton4);
            SetButtonList.Add(SetButton5);
            SetButtonList.Add(SetButton6);
            SetButtonList.Add(SetButton7);

            long space = GetTotalFreeSpace("C:\\");
            DiskSpaceLabel.Text = Convert.ToString(space / (1024 * 1024 * 1024)) + "GB";
            if (space / (1024 * 1024 * 1024) <= 1 && dispWar)
            {
                using (Form2 frm = new Form2())
                {
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Yes)
                    {
                        dispWar = false;
                    }
                }
            }

            // Turn those buttons off
            for (int i = 0; i < SetButtonList.Count(); i++)
            {
                SetButtonList[i].Enabled = false;
            }

            chart2.Titles.Add("FFT Plot");
            chart2.ChartAreas[0].AxisX.Title = "Frequency";
            chart2.ChartAreas[0].AxisY.Title = "Amplitude";
            chart1.ChartAreas[0].AxisX.Title = "Time (Minutes)";
            chart1.ChartAreas[0].AxisY.Title = "Amplitude";
            chart1.Titles.Add("FFT Peaks");

            BaudRateComboBox.Items.Add("19200");
            BaudRateComboBox.Items.Add("9600");
            BaudRateComboBox.SelectedIndex = 0;
        }

        // Turns a timestamp into a timestring
        private string GetTimeString(string TimeStamp)
        {
            string temp = TimeStamp.Replace(' ', '_');
            temp = temp.Replace(':', '-');

            return temp;
        }

        // This function will be for testing, reading data from file rather than from the Arduino
        private void ReadFromFile()
        {
            if (STOP)
            {
                return;
            }
            // get a timestamp and trun it into a timestring
            TimeStamp = Convert.ToString(DateTime.Now);
            TimeString = GetTimeString(TimeStamp);
            // adjust the label
            TaskLabel.Text = "Recieving Data";
            TaskLabel.Refresh();

            // start the stopwatch and get the end time for the 3-dimentional plot
            SW = new Stopwatch();
            SW.Start();
            end = DateTime.Now;

            //formatData();

            while ((input = Reader.ReadLine()) != null)
            {
                if (STOP)
                {
                    return;
                }
                lines = input.Split(',');
                double t;
                double amp;
                // This is for reading the file Faheem send me
                if (lines.Count() < 2)
                {
                    if (Double.TryParse(input, out amp))
                    {
                        //var mul = 0.0022;
                        //X.Add(count * mul);
                        if (serialPort1.BaudRate == 19200 || serialPort1.BaudRate == 9600)
                        {
                            time = count * mul;
                        }
                        X.Add(time);
                        Y.Add(amp);
                        count++;

                        // Update label every 200 points
                        if (count % 200 == 0)
                        {
                            DataPointsLabel.Text = Convert.ToString(count);
                            DataPointsLabel.Refresh();
                        }
                        if (count >= NumData)
                        {
                            GettingData = false;
                            break;
                        }
                    }
                }

                else if (lines.Count() == 2)
                {
                    if (Double.TryParse(lines[0], out t) && Double.TryParse(lines[1], out amp))
                    {
                        time = Convert.ToDouble(SW.ElapsedMilliseconds);

                        X.Add(Convert.ToDouble(lines[0]));
                        Y.Add(Convert.ToDouble(lines[1]));
                        count++;
                        Application.DoEvents();
                        if (count % 1000 == 0)
                        {
                            DataPointsLabel.Text = Convert.ToString(count);
                            DataPointsLabel.Refresh();
                        }
                        if (count >= NumData)
                        {
                            GettingData = false;
                            break;
                        }
                        //Thread.Sleep(4);
                    }
                    else { GettingData = false; break; }
                }
                else { GettingData = false; X.Add(0); break; }

            }
            Application.DoEvents();
            if (X.Count() > 0)
            {
                PerformFFT();
            }
            else
            {
                MessageBox.Show("Finished Data File");
            }

        }

        // Unused function for parsing a specific data file
        private void formatData()
        {
            while ((input = Reader.ReadLine()) != null)
            {
                lines = input.Split(' ');
                //lines[0].Replace(':', '');

            }
        }

        // A function to get the data from the arduino
        private void GetTheData()
        {
            if (STOP)
            {
                return;
            }

            ConnectionTextBox.Text = "Connection Good";
            ConnectionTextBox.BackColor = Color.Lime;

            bool read = false;
            while (GettingData && !STOP)
            {
                try
                {
                    // if we are collecting at the decided rate of 19200 bits per second then input that shit manually
                    if (serialPort1.BaudRate == 19200 || serialPort1.BaudRate == 9600)
                    {
                        time = count * mul;
                    } // else just take the time from the stopwatch

                    else { time = SW.ElapsedMilliseconds; }
                    double data;
                    timeout = new Stopwatch();
                    timeout.Start();
                    while(notRecieved)
                    {
                        if (timeout.ElapsedMilliseconds > 3000)
                        {
                            timeout.Reset();
                            notRecieved = false;
                            STOP = true;
                            ConnectionTextBox.Text = "Connection Bad";
                            ConnectionTextBox.BackColor = Color.Red;

                            DialogResult result = MessageBox.Show("Not receiving data from sensor. reset app?", "Warning",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                ResetButton.PerformClick();
                            }
                            else { STOP = true; notRecieved = false;
                            }
                        }
                        Application.DoEvents();
                    }
                    timeout = null;

                    if (double.TryParse(input, out data) && !STOP)
                    {
                        input = null;
                        notRecieved = true;
                        X.Add(time);
                        Y.Add(data);
                        //Writer.Write(time);
                        //Writer.Write(',');
                        //Writer.WriteLine(data);
                        count++;
                    }
                    if (count % 200 == 0)
                    {
                        DataPointsLabel.Text = Convert.ToString(count);
                        DataPointsLabel.Refresh();
                    }
                    if (count >= NumData)
                    {
                        GettingData = false;
                        TaskLabel.Text = "Reading Data";
                        read = true;
                        break;

                    }
                }
                catch { GatherDataTimer.Start(); break; }
                Application.DoEvents();
            }
            if (read)
            {
                //ReadData();
                WriteTime();
                //PerformFFT();
            }
        }

        // This function is unused - was for detecting poor connection
        public async Task ExecuteTaskAsync(int timespan)
        {
            cts = new CancellationTokenSource(timespan);
            try
            {
                input = await DoSomethingAsync(cts);
                notRecieved = false;
            }catch(TaskCanceledException)
            {
                DialogResult result = MessageBox.Show("Not Recieving Data from Sensor. Reset App?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ResetButton.PerformClick();
                }
                notRecieved = false;
            }
        }
        // Goes with the above function for detecting poor connection
        private Task<string> DoSomethingAsync(CancellationTokenSource token)
        {
            Task<string> task = null;

            task = Task.Run(() =>
            {
                string res = serialPort1.ReadLine();
                return res;
            });
            return task;
        }
        
        // Function that writes the time data to specifyed file
        private void WriteTime()
        {
            string pre = PrefixTextBox.Text;
            if (SaveDataCheckBox.Checked && SaveTimeCheckBox.Checked)
            {
                string Folder = System.IO.Path.Combine(directory, "TimeData");
                if (Directory.Exists(Folder))
                {
                    Writer = new System.IO.StreamWriter(Folder + "\\" + pre + "-" + TimeString + ".txt");
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Folder);
                    Writer = new System.IO.StreamWriter(Folder + "\\" + pre + "-" + TimeString + ".txt");
                }
                Writer.WriteLine("Data Points: " + Convert.ToString(X.Count()));
                Writer.WriteLine();
                Writer.WriteLine("Time Domain Data:");
                Writer.WriteLine();
                for (int i = 1; i < X.Count(); i++)
                {
                    Writer.Write(X[i]);
                    Writer.Write(", ");
                    Writer.WriteLine(Y[i]);
                }
                Writer.Close();
            }


            if (X.Count() < 20)
            {
                return;
            }
            else { PerformFFT(); }
        }

        // A function to help with closing the serial port
        private void CloseSerialOnExit()
        {
            try
            {
                serialPort1.Close(); //close the serial port
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //catch any serial port closing error messages
            }
        }

        // A simple timer to help recieve the data from the arduino with sufficient speed
        private void timer1_Tick(object sender, EventArgs e)
        {
            GatherDataTimer.Stop();
            GetTheData();
        }

        // This function gets the data from the file to the variables
        // Unused
        private void ReadData()
        {
            Writer.Close();
            Reader = new System.IO.StreamReader(filename);
            while ((input = Reader.ReadLine()) != null)
            {
                lines = input.Split(',');
                X.Add(Convert.ToDouble(lines[0]));
                Y.Add(Convert.ToDouble(lines[1]));
            }
            PerformFFT();
        }

        // Function for performing the FFT Transform
        private int PerformFFT()
        {
            TaskLabel.Text = "Performing FFT";
            TaskLabel.Refresh();

            // Get the FFT transform
            X = X.Skip(1).Take(X.Count() - 1).ToList();
            Y = Y.Skip(1).Take(Y.Count() - 1).ToList();
            double[] amp = Y.ToArray();
            double[] time = X.ToArray();
            X = new List<double>();
            Y = new List<double>();
            int samplesize = Y.Count();
            FFT = GetFFT(amp, time, samplesize);
            amp = null;
            time = null;
            // Now we need to write the FFT data
            // We may simply skip to plotting the data rather than writing all of the data
            // We may simply skip to finding peak rather than plotting data. both steps may be unnecessary and may slow down the collection

            WriteFFT();
            //PlotData();
            //FindPeaks();

            return 0;
        }

        // This function writes the fft data to the specifyed file
        private void WriteFFT()
        {
            TaskLabel.Text = "Writing FFT";
            TaskLabel.Refresh();

            // Select the file
            string pre = PrefixTextBox.Text;

            if (SaveDataCheckBox.Checked && FFTDataCheckBox.Checked)
            {
                string Folder = System.IO.Path.Combine(directory, "FFTData");
                if (Directory.Exists(Folder))
                {
                    Writer = new System.IO.StreamWriter(Folder + "\\" + pre + "-" + TimeString + ".txt");
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Folder);
                    Writer = new System.IO.StreamWriter(Folder + "\\" + pre + "-" + TimeString + ".txt");
                }
                Writer.WriteLine("FFT Data");

                // Write the file
                for (int i = 0; i < FFT.freq.Count(); i++)
                {
                    Writer.Write(Math.Round(FFT.freq[i], 2));
                    Writer.Write(", ");
                    Writer.WriteLine(Math.Round(FFT.fft[i], 2));
                    Application.DoEvents();
                }
                Writer.Close();
            }


            TaskLabel.Text = "Done Writing";
            TaskLabel.Refresh();

            // Now we need to plot the data
            PlotData();
        }

        // Reduced the number of points and plots the data
        private void PlotData()
        {
            // the start of this function cuts the number of point down to the 
            // desired plottable number, it does this by finding how often to 
            // plot a point, and plotting the largest value from each bin
            
            // Total number of points
            int tot = FFT.fft.Count();
            
            // Fund desired number of points to plot
            int pointsToPlot = Convert.ToInt32(PointsToPlotTextBox.Text);
            // Find how often we need to plot a point
            double mul = Math.Round(tot / Convert.ToDouble(pointsToPlot));
            // If it rounds to 0, plot every point
            if (mul == 0)
            {
                mul = 1;
            }
            // Clear the chart
            chart2.Series[0].Points.Clear();
            // for storing max value
            double max = FFT.fft[0];
            // for storing max frequency
            double maxfreq = FFT.freq[0];
            // Get the new, chopped data
            newX = new List<double>();
            newY = new List<double>();
            // Go through all the data
            for (int i = 0; i < FFT.fft.Count(); i++)
            {
                // if its no time to plot a point
                if (i % mul != mul - 1)
                {
                    // if the current value is larger than current max, make it the new max, along with corresponding frequency
                    if (FFT.fft[i] > max)
                    {
                        max = FFT.fft[i];
                        maxfreq = FFT.freq[i];
                    }

                }
                // otherwise it is time to take the point, so add it to the new data
                else
                {
                    newX.Add(maxfreq);
                    newY.Add(max);
                    //chart2.Refresh();
                    // if we have more data to reduce, reset the max and maxfreq to ther start of the next bin
                    if (i < FFT.fft.Count() - 1)
                    {
                        i++;
                        max = FFT.fft[i];
                        maxfreq = FFT.freq[i];
                    }
                    // otherwise they can simply be 0
                    else
                    {
                        max = 0;
                        maxfreq = 0;
                    }

                }
            }
            // Plot the reduced data
            chart2.Series[0].Points.DataBindXY(newX, newY);
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0.0}";
            //chart1.Refresh();
            chart2.Refresh();

            // Time to save the plot
            string pre = PrefixTextBox.Text;

            // Save the data if desired
            if (SaveDataCheckBox.Checked && FFTChartCheckBox.Checked)
            {
                string Folder = System.IO.Path.Combine(directory, "FFTChart");
                if (Directory.Exists(Folder))
                {
                    chart2.SaveImage(Folder + "\\" + pre + TimeString + ".Png", ChartImageFormat.Png);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Folder);
                    chart2.SaveImage(Folder + "\\" + pre + TimeString + ".Png", ChartImageFormat.Png);
                }
            }
            FindPeaks();
        }

        // This function finds the peaks
        private void FindPeaks()
        {
            // Set the label
            TaskLabel.Text = "Finding Peaks";
            TaskLabel.Refresh();

            // Add the Time value to the peak list
            PeakList.Add(new List<Tuple<double, double>>());

            // This part will add the largest values of the chart to a list for this round of data collection
            // get the range of values we are dealing with
            double freqRange = EndFreq - StartFreq;
            // this part calculates how many peaks we can find
            int temp = Convert.ToInt32(freqRange / (Tolerance * 2));
            if (NumData >= pointsToPlot)
            {
                loop = temp + 1;
            }
            else { loop = temp; }
            if (newX.Count() >= loop)
            {
            }
            else { loop = newX.Count(); }
            if (Convert.ToInt32(NumPeaksTextBox.Text) < loop)
            {
                loop = Convert.ToInt32(NumPeaksTextBox.Text);
            }
            // now we have the number of points we will find, stored in loop
            // loop through once each to find themto find them
            for (int i = 0; i < loop; i++)
            {
                // continue to loop till the value is found
                while (true)
                {
                    // get the current max value
                    double max = newY.Max();
                    // get index of max value
                    int index = newY.IndexOf(max);
                    // kill that data point so it wont be used again
                    newY[index] = 0;
                    // get the max frequency value
                    double maxfreq = newX[index];
                    // check to see if that frequency value is valid (not within the tolerence of an already found value
                    if (ValidPeak(maxfreq))
                    {
                        // if it is, add the value to our peak list
                        PeakList.Last().Add(new Tuple<double, double>(ToSignificantDigits(Math.Round(maxfreq, 2), 2), ToSignificantDigits(Math.Round(max, 2), 2)));
                        break;
                    }
                }

            }
            // if desired, save the peak data
            string pre = PrefixTextBox.Text;

            if (SaveDataCheckBox.Checked && PeakDataCheckBox.Checked)
            {
                string Folder = System.IO.Path.Combine(directory, "PeakData");
                if (Directory.Exists(Folder))
                {
                    Writer = new System.IO.StreamWriter(Folder + "\\" + pre + "-" + TimeString + ".txt");
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Folder);
                    Writer = new System.IO.StreamWriter(Folder + "\\" + pre + "-" + TimeString + ".txt");
                }
                Writer.WriteLine("Data Points: " + Convert.ToString(X.Count()));
                Writer.WriteLine();
                Writer.WriteLine("FFT Peaks:");
                Writer.WriteLine();
                for (int i = 0; i < PeakList.Last().Count(); i++)
                {
                    Writer.Write(PeakList.Last()[i].Item1);
                    Writer.Write(", ");
                    Writer.WriteLine(PeakList.Last()[i].Item2);
                }
                Writer.Close();
            }

            // this part attempted to eliminate harmonics, guess we arent doing that
            #region Try to eliminate Harmonics from the peak list
            // Now we will check for harmonics in a very basic fashion and remove them from the data. This is unnecessary at this point in time, and the code doesnt quite work. Will leave it for future reference.
            // A double for loop may be the best way, O(n^2) isn't too bad in this case since the peak list only contains about 20 points.

            //double freqMax = PeakList.Last()[0].Item1;
            //List<int> inds = new List<int>();
            //for (int i = 1; i < PeakList.Last().Count(); i++)
            //{
            //    if (PeakList.Last()[i].Item1 % freqMax == 0)
            //    {
            //        PeakList.Last().RemoveAt(i);
            //        inds.Add(i);
            //    }
            //}
            //for (int i = 0; i < inds.Count(); i++)
            //{
            //    PeakList.Last().RemoveAt(inds[i]);
            //}
            #endregion

            // update the label
            TaskLabel.Text = "Found Peaks";
            TaskLabel.Refresh();


            // Display all the data in the grid view

            // Now we need to populate the Tab Control
            TabPage page = new TabPage();
            page.Text = TimeStamp;
            MainTab.TabPages.Add(page);

            DataGridView dataGridView = new DataGridView();
            //ASDF
            dataGridView.RowPostPaint += AddRow;
            //dataGridView.Columns[0].Name = "Rank";

            page.Controls.Add(dataGridView);

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Dock = DockStyle.Left;
            dataGridView.Width = page.Width;
            dataGridView.DataSource = PeakList.Last();
            dataGridView.Columns[0].HeaderText = "Frequency";
            dataGridView.Columns[1].HeaderText = "Amplitude";

            dataGridView.Refresh();

            page.Refresh();
            page.Focus();
            dataGridView.Refresh();
            MainTab.Refresh();

            // We're now going to try to Make a three dimentional plot using the TimeStamp as the X Axis Value
            TaskLabel.Text = "Three Dim Plot";
            TaskLabel.Refresh();
            ThreeDimentionalPlot();

            // Now reset and get the next batch of data
            TaskLabel.Text = "Resetting";
            TaskLabel.Refresh();
            ResetApp();
        }

        // Format the value with the indicated number of significant digits.
        public static double ToSignificantDigits(
            double value, int significant_digits)
        {
            if (value < 1)
            {
                // Use G format to get significant digits.
                // Then convert to double and use F format.
                string format1 = "{0:G" + significant_digits.ToString() + "}";
                string result = Convert.ToDouble(
                    String.Format(format1, value)).ToString("F99");

                // Rmove trailing 0s.
                result = result.TrimEnd('0');

                // Rmove the decimal point and leading 0s,
                // leaving just the digits.
                string test = result.Replace(".", "").TrimStart('0');

                // See if we have enough significant digits.
                if (significant_digits > test.Length)
                {
                    // Add trailing 0s.
                    result += new string('0', significant_digits - test.Length);
                }
                else
                {
                    // See if we should remove the trailing decimal point.
                    if ((significant_digits < test.Length) &&
                        result.EndsWith("."))
                        result = result.Substring(0, result.Length - 1);
                }
                double temp = Convert.ToDouble(result);

                return temp;

            }
            else
            {
                return Math.Round(value, significant_digits);
            }
        }

        // This function takes the tolerance level and past peaks and tells you whether it qualifies as a different peak.
        private bool ValidPeak(double freq)
        {
            // if the frequency is not within the frequency range, invalid
            if (freq < StartFreq || freq > EndFreq)
            {
                return false;
            }
            // got through already selected peaks
            for (int k = 0; k < PeakList.Last().Count(); k++)
            {
                // if it is outside of the tolerance
                if (freq < PeakList.Last()[k].Item1 - Tolerance || freq > PeakList.Last()[k].Item1 + Tolerance)
                {
                    // then its good
                }
                else
                {
                    // this means that the freqency we are currently looking at can count as another existing peak, and thus it is not a valid new peak
                    return false;
                }
            }
            // if it made it through the loop without returning false, that it is valid
            return true;
        }

        // this function performs the three dimentional plot
        private void ThreeDimentionalPlot()
        {
            // This function currently needs to change to represent the tolerance level for determining peaks

            // Get the Time of the X index that we are going to add to the chart
            var xValue = end;
            // get a list to hold currently used frequencies
            List<Double> used = new List<double>();
            // set up label format
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{H:mm \n dd/MM/yy}";
            
            // figure out how many times we need to loop
            if (PeakList.Last().Count() < loop)
            {
                loop = PeakList.Last().Count();
            }
            // now sort the data into the chart
            for (int i = 0; i < loop; i++)
            {
                // store the values individually, simply easier for the next part
                double x = PeakList.Last()[i].Item1;
                double y = PeakList.Last()[i].Item2;

                // If we dont already have a series for that frequency
                if (!SeriesContains(x, out double S))
                {
                    // now we do
                    PeakSeries[x] = y;
                    // add the series
                    chart1.Series.Add(Convert.ToString(x));
                    // set the data type
                    chart1.Series.Last().XValueType = ChartValueType.DateTime;
                    // set the chart type
                    chart1.Series.Last().ChartType = SeriesChartType.Point;
                    // set border width
                    chart1.Series.Last().BorderWidth = 3;
                    // enable the series
                    chart1.Series.Last().Enabled = true;
                    // add the value
                    chart1.Series.Last().Points.AddXY(xValue, y);
                    // this frequency is currently used
                    used.Add(x);
                }
                // if we are already have a series for it, but havent used it for this timespan yet
                else if (!used.Contains(S))
                {
                    // find the series we have for this frequency
                    int ind = chart1.Series.IndexOf(Convert.ToString(S));
                    // add the value
                    chart1.Series[ind].Points.AddXY(xValue, y);
                    // set the chart type, just in case
                    chart1.Series[ind].ChartType = SeriesChartType.Line;
                    // now we have used this frequency
                    used.Add(S);
                }
                // otherwise we arent going to use it.
            }

            // Adds a scrollable bar
            double Xmax = 0;
            double numPoints = 0;
            double Xmin = 1000000;
            // this is to determine if we need it
            foreach (Series S in chart1.Series)
            {
                if (S.Points.Count() > numPoints)
                {
                    numPoints = S.Points.Count();
                }
                if (S.Points.Last().XValue > Xmax)
                {
                    Xmax = S.Points.Last().XValue;
                }
                if (S.Points.First().XValue < Xmin)
                {
                    Xmin = S.Points.First().XValue;
                }
            }
            // set the block size
            double blockSize = (Xmax - Xmin) / (numPoints / 10);
            // find the start location for zooming in
            double start = Xmax - blockSize;
            // we will need to implement if we have more than 10 time points
            if (numPoints > 10)
            {
                // set view range to [0,max]
                chart1.ChartAreas[0].AxisX.Minimum = Xmin;
                chart1.ChartAreas[0].AxisX.Maximum = Xmax;

                // enable autoscroll
                chart1.ChartAreas[0].CursorX.AutoScroll = true;

                // let's zoom to [0,blockSize] (e.g. [0,100])
                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                chart1.ChartAreas[0].AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
                //int position = Convert.ToInt32(Xmax - blockSize);
                double position = start;
                double size = blockSize;
                chart1.ChartAreas[0].AxisX.ScaleView.Zoom(position, position + size);

                // disable zoom-reset button (only scrollbar's arrows are available)
                chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

                // set scrollbar small change to blockSize (e.g. 100)
                chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = blockSize;
            }
            // get this chart working
            chart1.Enabled = true;
            try
            {
                chart1.Refresh();
            }
            catch { }

            // if desired, save the peak image
            string pre = PrefixTextBox.Text;

            if (SaveDataCheckBox.Checked && PeakChartCheckBox.Checked)
            {
                string Folder = System.IO.Path.Combine(directory, "PeakImage");
                if (Directory.Exists(Folder))
                {
                    chart1.SaveImage(Folder + "\\" + pre + TimeString + ".Png", ChartImageFormat.Png);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Folder);
                    chart1.SaveImage(Folder + "\\" + pre + TimeString + ".Png", ChartImageFormat.Png);
                }
            }
        }

        // this function checks if we already have a series for that frequency
        private bool SeriesContains(double x, out double val)
        {
            // will output val (being the name of the series that currently uses the frequency) if we do
            // start val off as 0
            val = 0;
            // start dif very high
            double dif = 100000;
            // assume we dont
            bool ans = false;
            // go through our dictionary of Peak Frequencies
            foreach (double key in PeakSeries.Keys)
            {
                // get how close frequency is to the key we're looking at
                double tempdif = Math.Abs(x - key);
                // if tempdif is within tolerance and lower than current dif
                if (tempdif <= Tolerance && tempdif <= dif)
                {
                    // set the new dif
                    dif = tempdif;
                    // there is definitely a series that account for this frequency
                    ans = true;
                    // set the val to this key, which is the closest one at this point
                    val = key;
                }
            }
            // return the ans
            return ans;
        }

        // This function performs some cleanup, then resets to grab another chunk of data
        private void ResetApp()
        {
            // reset some values
            SW = new Stopwatch();
            X = new List<double>();
            Y = new List<double>();
            GettingData = true;
            count = 0;

            // get the available space
            long space = GetTotalFreeSpace("C:\\");
            DiskSpaceLabel.Text = Convert.ToString(space / (1024 * 1024 * 1024)) + "GB";
            // if there is less than 1 GB of available storage, notify user
            if (space/ (1024*1024*1024) <= 1 && dispWar)
            {
                using (Form2 frm = new Form2())
                {
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Yes)
                    {
                        dispWar = false;
                    }
                }
            }
            //GetTheData();

            // if we are collecting data from sensor
            if (Arduino)
            {
                // adjust extra stuff
                TaskLabel.Text = "Recieving Data";
                TaskLabel.Refresh();
                TimeStamp = Convert.ToString(DateTime.Now);
                TimeString = GetTimeString(TimeStamp);
                end = DateTime.Now;
                ResetAppTimer.Start();
            }
            else
            {
                // else just get the next batch
                ResetAppTimer.Start();
            }
        }

        // This class holds the fft data
        public class FFTData
        {
            public List<double> freq { get; set; }
            public List<double> fft { get; set; }
        }

        // Function that performs the FFT transform
        private FFTData GetFFT(double[] amp, double[] time, int SampleCount)
        {
            FFTData fftData = new FFTData(); // get the answer fft data
            double[] fft = new double[amp.Count()]; // open an array for the fft values
            double[] freq = new double[amp.Count() / 2]; // open an array for the freqency values
            // if there is hardly any data assume something went wrong
            if (time.Count() < 10)
            {
                for (int i = 0; i < amp.Count() / 2; i++)
                {
                    freq[i] = i;
                }
            }
            else
            {
                // find the increment of frequency for each bin
                double mul = 1.0 / ((time.Last() - time[0]) / 1000);
                // round it to 5 decimal places
                mul = Math.Round(mul, 5);
                //MessageBox.Show(Convert.ToString(mul));
                double j = mul;
                // Assign the frequency values
                for (int count = 0; count < freq.Count(); count++)
                {
                    freq[count] = j;
                    j = j + mul;
                }
            }
            // kill the time value to save space
            time = null;

            // If there are too many points to use the built in function, use my own implementation
            // This implementation currently doesn work. I am currently simply Trimming and simplifying the data before calling this function so I dont need an implementation of the FFT that can handle over 100 thousand data points.
            if (amp.Count() > 40000000)
            {
                double[] fftComplex = amp;

                //double[] ans = SendToPython(fftComplex); // Perform the fft

                //fftData.fft = ans;
                fftData.fft = fftComplex.ToList();
                fftData.freq = freq.ToList();

                return fftData;
            }
            else // otherwise simply use the built in function
            {
                Complex[] fftComplex;
                fftComplex = new Complex[amp.Length]; // initialize the complex array

                for (int i = 0; i < amp.Length; i++) // fill the complex array with the time values
                {
                    fftComplex[i] = new Complex(amp[i], 0);
                    Application.DoEvents();
                }
                amp = null;

                //Perform the FFT
                Accord.Math.Transforms.FourierTransform2.FFT(fftComplex, Accord.Math.FourierTransform.Direction.Forward);

                // transform fft based on user selected style
                for (int i = 0; i < fftComplex.Length; i++)
                {
                    // Get the Magnitude
                    fft[i] = fftComplex[i].Magnitude;
                    Application.DoEvents();
                }

                fft = fft.Skip(6).Take(fft.Length / 2).ToArray(); // Take half the values

                // Throw the values into the result
                fftData.fft = fft.ToList();
                fftData.freq = freq.ToList();

                return fftData; // return the result
            }
        }

        // This add row function is a helper function to fill the data graph view with data
        private static void AddRow(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, grid.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        // Function for colecting data from a file
        private void FromFileButton_Click(object sender, EventArgs e)
        {
            // turn many controls off
            StopCollectingButton.Enabled = true;
            Arduino = false;
            FromFileButton.Enabled = false;
            FromArduinoButton.Enabled = false;
            StopCollectingButton.Enabled = true;
            ResetButton.Enabled = true;

            NumDataPointsTextBox.ReadOnly = true;
            PointsToPlotTextBox.ReadOnly = true;
            ToleranceTextBox.ReadOnly = true;
            PrefixTextBox.ReadOnly = true;
            SaveDataCheckBox.Enabled = false;

            // adjust the label
            TaskLabel.Text = "Recieving Data";
            TaskLabel.Update();

            // if desired, save the chart image
            if (SaveDataCheckBox.Checked)
            {
                //Get the directory for storing the FFT Data
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        directory = fbd.SelectedPath;
                    }
                }
            }

            // set the increment for time values based on the BaudRate Selected
            if (serialPort1.BaudRate == 19200)
            {
                mul = 4;
            }else if(serialPort1.BaudRate == 9600)
            {
                mul = 8;
            }

            count = 0;
            // Select the data file for reading the time data
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
            }
            Reader = new System.IO.StreamReader(filename);
            start = DateTime.Now;
            // read from the file
            ReadFromFile();
        }

        // The function when the reading data button is pressed, this function triggers all of the other function in the file
        private void FromArduinoButton_Click(object sender, EventArgs e)
        {
            // If no serial port is selected, warn the user and make them pick one
            if (comboBox1.Text == "")
            {
                DialogResult result = MessageBox.Show("Serial port cannot be left blank, please select a serial port", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    return;
                }
            }

            // turn off many controls
            StopCollectingButton.Enabled = true;
            Arduino = true;
            FromFileButton.Enabled = false;
            FromArduinoButton.Enabled = false;
            StopCollectingButton.Enabled = true;
            ResetButton.Enabled = true;

            SaveTimeCheckBox.Enabled = false;
            FFTChartCheckBox.Enabled = false;
            FFTDataCheckBox.Enabled = false;
            PeakChartCheckBox.Enabled = false;
            PeakDataCheckBox.Enabled = false;

            // update the label
            TaskLabel.Text = "Recieving Data";
            TaskLabel.Update();

            // configure the serial port
            serialPort1.PortName = comboBox1.Text; // name the serial port
            serialPort1.BaudRate = 19200;
            if (BaudRateComboBox.SelectedItem.ToString() == "19200")
            {
                serialPort1.BaudRate = 19200;
            }
            else if (BaudRateComboBox.SelectedItem.ToString() == "9600")
            {

                serialPort1.BaudRate = 9600;
            }
            // close to reset the serial port
            serialPort1.Close();
            // get a new stopwatch
            SW = new Stopwatch();
            // we are now collecting data
            GettingData = true;

            // get the number of points to plot
            pointsToPlot = Convert.ToInt32(PointsToPlotTextBox.Text);

            // if we want to save some data, pick the directory to save it
            if (SaveDataCheckBox.Checked)
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        directory = fbd.SelectedPath;
                    }
                }
            }

            // grab the increment for time values based on baudrate
            if (serialPort1.BaudRate == 19200)
            {
                mul = 2;
            }
            else if (serialPort1.BaudRate == 9600)
            {
                mul = 4;
            }

            // configure some controls
            NumDataPointsTextBox.ReadOnly = true;
            PointsToPlotTextBox.ReadOnly = true;
            ToleranceTextBox.ReadOnly = true;
            PrefixTextBox.ReadOnly = true;
            SaveDataCheckBox.Enabled = false;
            BaudRateComboBox.Enabled = false;
            NumPeaksTextBox.Enabled = false;

            // set some stuff up
            count = 0;
            start = DateTime.Now;
            serialPort1.Open();
            TimeStamp = Convert.ToString(DateTime.Now);
            TimeString = GetTimeString(TimeStamp);
            SW.Start();
            end = DateTime.Now;
            GetTheData();
        }

        // function for stopping the collection of data
        private void StopCollectingButton_Click(object sender, EventArgs e)
        {
            // stop is true
            STOP = true;
            // cant hit the button more than once in a row
            StopCollectingButton.Enabled = false;

            // Write time if we were grabbing from arduino and have many data points
            if (Arduino && X.Count() > 10)
            {
                WriteTime();
            }
            // else do the fft
            else if (X.Count() > 10)
            {
                PerformFFT();
            }
            // close the port
            serialPort1.Close();
            TaskLabel.Text = "Nothing";
        }

        // if you click on the Peak chart
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            /*
             * This will essentially check to see if you clicked on a series in the chart, if you did it will enable PlaceLabel, wich will allow you to add it to the custom Legend.
             * */
            // Call Hit Test Method
            HitTestResult hitResult = chart1.HitTest(e.X, e.Y);
            try
            {
                if (hitResult.Series.Points != null) // null pointer exception here
                {
                    name = hitResult.Series.Name;
                    PlaceLabel = true;
                    for (int i = 0; i < SetButtonList.Count(); i++)
                    {
                        SetButtonList[i].Enabled = true;
                    }
                }
                else { return; }
            }
            catch { return; }

        }

        #region Boring SetButtons for Legend

        // If you click set button 1, and were in placelabel mode, will adjust the freq label and change focus to the text box so you can label the series on the chart
        private void SetButton1_Click(object sender, EventArgs e)
        {
            if (PlaceLabel)
            {
                LabelList[0].Text = "Freq: " + name;
                TextBoxList[0].Focus();
                for (int i = 0; i < SetButtonList.Count(); i++)
                {
                    SetButtonList[i].Enabled = false;
                }
                PlaceLabel = false;
            }
        }

        // If you click set button 2, and were in placelabel mode, will adjust the freq label and change focus to the text box so you can label the series on the chart
        private void SetButton2_Click(object sender, EventArgs e)
        {
            if (PlaceLabel)
            {
                LabelList[1].Text = "Freq: " + name;
                TextBoxList[1].Focus();
                for (int i = 0; i < SetButtonList.Count(); i++)
                {
                    SetButtonList[i].Enabled = false;
                }
                PlaceLabel = false;
            }
        }

        // If you click set button 3, and were in placelabel mode, will adjust the freq label and change focus to the text box so you can label the series on the chart
        private void SetButton3_Click(object sender, EventArgs e)
        {
            if (PlaceLabel)
            {
                LabelList[2].Text = "Freq: " + name;
                TextBoxList[2].Focus();
                for (int i = 0; i < SetButtonList.Count(); i++)
                {
                    SetButtonList[i].Enabled = false;
                }
                PlaceLabel = false;
            }
        }

        // If you click set button 4, and were in placelabel mode, will adjust the freq label and change focus to the text box so you can label the series on the chart
        private void SetButton4_Click(object sender, EventArgs e)
        {
            if (PlaceLabel)
            {
                LabelList[3].Text = "Freq: " + name;
                TextBoxList[3].Focus();
                for (int i = 0; i < SetButtonList.Count(); i++)
                {
                    SetButtonList[i].Enabled = false;
                }
                PlaceLabel = false;
            }
        }

        // If you click set button 5, and were in placelabel mode, will adjust the freq label and change focus to the text box so you can label the series on the chart
        private void SetButton5_Click(object sender, EventArgs e)
        {
            if (PlaceLabel)
            {
                LabelList[4].Text = "Freq: " + name;
                TextBoxList[4].Focus();
                for (int i = 0; i < SetButtonList.Count(); i++)
                {
                    SetButtonList[i].Enabled = false;
                }
                PlaceLabel = false;
            }
        }

        // If you click set button 6, and were in placelabel mode, will adjust the freq label and change focus to the text box so you can label the series on the chart
        private void SetButton6_Click(object sender, EventArgs e)
        {
            if (PlaceLabel)
            {
                LabelList[5].Text = "Freq: " + name;
                TextBoxList[5].Focus();
                for (int i = 0; i < SetButtonList.Count(); i++)
                {
                    SetButtonList[i].Enabled = false;
                }
                PlaceLabel = false;
            }
        }

        // If you click set button 7, and were in placelabel mode, will adjust the freq label and change focus to the text box so you can label the series on the chart
        private void SetButton7_Click(object sender, EventArgs e)
        {
            if (PlaceLabel)
            {
                LabelList[6].Text = "Freq: " + name;
                TextBoxList[6].Focus();
                for (int i = 0; i < SetButtonList.Count(); i++)
                {
                    SetButtonList[i].Enabled = false;
                }
                PlaceLabel = false;
            }
        }
        #endregion

        #region Set Tolerance Controls
        // This function ensures that the user's tolerance choice is valid, I.E., a double
        private void ToleranceTextBox_TextChanged(object sender, EventArgs e)
        {
            // parse the user's choice, if is valid, use it
            bool isValid = double.TryParse(ToleranceTextBox.Text, out double dub);
            if (isValid)
            {
                Tolerance = dub;
            }
            else
            {
                // otherwise reset to last value and notify user
                ToleranceTextBox.Text = Convert.ToString(Tolerance);
                MessageBox.Show("Tolerance Value Must Be A Double");
            }
        }

        // simply check if it is valid if you change focus
        private void ToleranceTextBox_Leave(object sender, EventArgs e)
        {
            bool isValid = double.TryParse(ToleranceTextBox.Text, out double dub);
            if (isValid)
            {
                Tolerance = dub;
            }
            else
            {
                ToleranceTextBox.Text = Convert.ToString(Tolerance);
                MessageBox.Show("Tolerance Value Must Be A Double");
            }
        }

        // sets it
        private void SetToleranceFunc()
        {
            Tolerance = Convert.ToDouble(ToleranceTextBox.Text);
        }

        #endregion


        // this function sets the number of data points we will use for each peice of analysis
        private void SetNumDataFunc()
        {
            // parse it
            Int32.TryParse(NumDataPointsTextBox.Text, out NumData);
            int m = 0;
            // set how many points we are going to recieve per second based on baud rate
            if (serialPort1.BaudRate == 19200)
            {
                m = 250;
            }else if (serialPort1.BaudRate == 9600)
            {
                m = 125;
            }

            // Find the number of seconds it will take to collect that much data
            int seconds = NumData / m;
            // get the number of minutes that will take
            int minutes = Convert.ToInt32(seconds) / 60;
            // the the number of remaining seconds
            if (seconds > 60)
            {
                seconds = NumData % 60;
            }
            int hour;
            // if it will take over an hour, find the number of hours, and remaining minutes
            if (minutes > 60)
            {
                hour = minutes / 60;
                minutes = minutes % 60;
                // set the label
                NumMinutesLabel.Text = String.Format("{0}:{1}:{2}", hour, minutes, seconds);
            }
            else
            {
                // otherwise just set the label
                NumMinutesLabel.Text = String.Format("{0}:{1}", minutes, seconds);
            }
        }
       
        // Set the number of points to plot function
        private void SetPointsToPlotFunc()
        {
            // parse user input
            bool isValid = int.TryParse(PointsToPlotTextBox.Text, out int I);
            // if it is an int and less than 40 000 (to save the poor chart)
            if (isValid && I <= 40000)
            {
                // set the value
                pointsToPlot = I;
            }
            else
            {
                // else set it back to previous value and let user know
                PointsToPlotTextBox.Text = Convert.ToString(Tolerance);
                MessageBox.Show("Points To Plot Must be an Integer Between 250 and 40000");
            }
        }

        // ste number of peaks function
        private void SetNumPeaksFunc()
        {
            // find the frequency range
            double FreqRange = EndFreq - StartFreq;
            // get max certain number of findable peaks considering freq range and tolerance
            int maxPeaks = Convert.ToInt32(FreqRange / (Tolerance * 2));
            // make sure we are collecting more points than points to plot
            if (Convert.ToDouble(NumDataPointsTextBox.Text) >= Convert.ToDouble(PointsToPlotTextBox.Text))
            {
                maxPeaks += 1;
            }
            // if user wants more peaks than are possible, over-ride them
            if (maxPeaks < Convert.ToInt32(NumPeaksTextBox.Text))
            {
                NumPeaksTextBox.Text = Convert.ToString(maxPeaks);
            }
        }

        // is user clicks on chart2
        private void chart2_MouseClick(object sender, MouseEventArgs e)
        {
            // Function that grabs the point in the chart and puts the values in the correct label

            // get the mouse position
            var pos = e.Location;
            // get x and y values
            var Xval = chart2.ChartAreas[0].AxisX.PixelPositionToValue(pos.X);
            var Yval = chart2.ChartAreas[0].AxisY.PixelPositionToValue(pos.Y);

            // adjust the labels
            xValueLabel.Text = Convert.ToString(Math.Round(Xval, 1));
            yValueLabel.Text = Convert.ToString(Math.Round(Yval, 1));

            // fill the start freq text box if it was selected
            if (StartFreqSelect)
            {
                StartFreqTextBox.Text = Convert.ToString(Math.Round(Xval, 1));
                StartFreqSelect = false;

                StartFrequencyButton.Enabled = true;
                StartFreqTextBox.Enabled = true;
                EndFreqTextBox.Enabled = true;
                EndFrequencyButton.Enabled = true;
            }

            // fill the end freq text box if it was selected
            if (EndFreqSelect)
            {
                EndFreqTextBox.Text = Convert.ToString(Math.Round(Xval, 1));
                EndFreqSelect = false;

                StartFrequencyButton.Enabled = true;
                StartFreqTextBox.Enabled = true;
                EndFreqTextBox.Enabled = true;
                EndFrequencyButton.Enabled = true;
            }
        }

        // Sets all the settings by calling their respective functions
        private void SetSettingsButton_Click(object sender, EventArgs e)
        {
            SetBaudRate();
            SetPointsToPlotFunc();
            SetNumDataFunc();
            SetToleranceFunc();
            SetNumPeaksFunc();
        }

        // sets the baud-rate, very straightforward
        private void SetBaudRate()
        {
            serialPort1.BaudRate = Convert.ToInt32(BaudRateComboBox.Text);
        }

        // function for when the reset button is clicked
        private void ResetButton_Click(object sender, EventArgs e)
        {
            // if we are stopped, no need to stop
            if (STOP) { }
            // else click stop
            else { StopCollectingButton_Click(sender, e); }

            // turn many controls on
            NumDataPointsTextBox.ReadOnly = false;
            PointsToPlotTextBox.ReadOnly = false;
            ToleranceTextBox.ReadOnly = false;
            PrefixTextBox.ReadOnly = false;
            SaveDataCheckBox.Enabled = true;

            FromArduinoButton.Enabled = true;
            FromFileButton.Enabled = true;
            StopCollectingButton.Enabled = false;

            // adjust the connection label
            ConnectionTextBox.Text = "No Connection";
            ConnectionTextBox.BackColor = Color.Ivory;

            // setup the ports
            string[] portNames = SerialPort.GetPortNames(); // Get Port names
            StopCollectingButton.Enabled = false;
            comboBox1.Items.Clear();
            foreach (string name in portNames) // Add the port names to the port selection comboBox
            {
                comboBox1.Items.Add(name);
            }

            // reset many data structures to start conditions
            STOP = false;
            newX = new List<Double>();
            newY = new List<double>();
            X = new List<double>();
            Y = new List<double>();
            FFT = new FFTData();
            PeakList = new List<List<Tuple<double, double>>>();
            PeakSeries = new Dictionary<double, double>();
            SW = new Stopwatch();
            //PeakSeries = new Dictionary<Double, Double>();

            // reset the charts
            chart2.Series[0].Points.Clear();
            chart2.Refresh();

            while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
            chart1.Refresh();

            // reset label
            DataPointsLabel.Text = "0";

            // reset data graph view 
            MainTab.Dispose();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.MainTab.Location = new System.Drawing.Point(0, 272);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(332, 393);
            this.MainTab.TabIndex = 8;

            this.Controls.Add(this.MainTab);
            MainTab.Refresh();
            //int temp = MainTab.TabPages.Count;
            //for (int i = 0; i < MainTab.TabPages.Count; i++)
            //{
            //    MainTab.TabPages.RemoveAt(0);
            //}
            //MainTab.Refresh();

            // reset the custom legend
            foreach (Button button in SetButtonList)
            {
                button.Enabled = false;
            }
            foreach (TextBox textbox in TextBoxList)
            {
                textbox.Text = "";
            }
            foreach (Label label in LabelList)
            {
                label.Text = "";
            }
        }

        // allows user to selects the start frequency
        private void StartFrequencyButton_Click(object sender, EventArgs e)
        {
            EndFrequencyButton.Enabled = false;
            StartFreqTextBox.Enabled = false;
            EndFreqTextBox.Enabled = false;

            StartFreqSelect = true;
        }

        // allows user to select the end frequency
        private void EndFrequencyButton_Click(object sender, EventArgs e)
        {
            StartFrequencyButton.Enabled = false;
            StartFreqTextBox.Enabled = false;
            EndFreqTextBox.Enabled = false;

            EndFreqSelect = true;
        }

        // applies the start and end frequency restrictions to the analysis
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            // first, ensure that start and end frequenies are valid
            if (!Double.TryParse(StartFreqTextBox.Text, out StartFreq))
            {
                MessageBox.Show("Start Frequency Must Be a Double");
            }
            else if (!Double.TryParse(EndFreqTextBox.Text, out EndFreq))
            {
                MessageBox.Show("End Frequency Must Be a Double");
            }
            else if (!(EndFreq > StartFreq))
            {
                MessageBox.Show("End Frequency Must Be Larger Than Start Frequency");
            }
            else
            {
                // then warn user that app will reset
                DialogResult result = MessageBox.Show("This will reset all settings. Continue?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    //code for Yes

                    StopCollectingButton_Click(sender, e);
                    ResetButton_Click(sender, e);
                }
                else if (result == DialogResult.No)
                {
                    //code for No
                }
            }
        }

        // Timer for resetting app
        private void ResetAppTimer_Tick(object sender, EventArgs e)
        {
            // turn off timer (not repeating)
            ResetAppTimer.Stop();
            // start stopwatch
            SW.Start();
            // continue grabbing data
            if (Arduino)
            {
                GetTheData();
            }
            else
            {
                ReadFromFile();
            }
        }
        
        // store the data when it is received
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            input = serialPort1.ReadLine();
            notRecieved = false;
        }

        // function that gets the free space on the disk
        private long GetTotalFreeSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return drive.TotalFreeSpace;
                }
            }
            return -1;
        }

        // simply lets user check other save data options
        private void SaveDataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SaveDataCheckBox.Checked == true)
            {
                SaveTimeCheckBox.Enabled = true;
                FFTChartCheckBox.Enabled = true;
                FFTDataCheckBox.Enabled = true;
                PeakChartCheckBox.Enabled = true;
                PeakDataCheckBox.Enabled = true;
            }
            else
            {
                SaveTimeCheckBox.Enabled = false;
                FFTChartCheckBox.Enabled = false;
                FFTDataCheckBox.Enabled = false;
                PeakChartCheckBox.Enabled = false;
                PeakDataCheckBox.Enabled = false;
            }
        }

        //private void UpdateChartCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (UpdateChartCheckBox.Checked == true)
        //    {
        //        Update = true;
        //    }
        //    else { Update = false; }
        //}
    }
}
