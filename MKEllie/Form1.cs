using System;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Drawing;

namespace MKNaomi
{
    public partial class frmMKEllie : Form
    {

        string shortSerial = string.Empty;
        string shortRegion = string.Empty;
        bool threadRunning = false;
        public frmMKEllie()
        {
            InitializeComponent();
        }
        private void xmlDBRead(string gameName)
        {
            try
            {
                //clean up stop characters in the string and make it all into a . between
                gameName = gameName.Replace('_', '.');
                gameName = gameName.Replace(' ', '.');
                string[] nameParts = gameName.Split('.');
                int[] matchValue = new int[9000];
                //define variables to send to the DataGrid
                string name = string.Empty;
                string serial = string.Empty;
                string region = string.Empty;
                int largestIndex = 0;
                int largestValue = -1;
                double confidence = 0.0;
                bool[] matching = new bool[9000];
                bool success = false;
                int matchCount = 0;
                //Read XML File and load to DataSet
                XmlReader xmlFile;
                xmlFile = XmlReader.Create(Environment.CurrentDirectory + "\\Data\\3dsreleases.xml", new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                DataTable dt = ds.Tables[0];
                //see how many of the name parts match the current game in the array
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < nameParts.Length; j++)
                    {
                        string nameStore = dt.Rows[i]["name"].ToString();
                        region = dt.Rows[i]["region"].ToString();
                        if (nameStore.Contains(nameParts[j])&& region==cboCountry.Text)
                        {
                            matching[j] = true;

                        }
                        else
                        {
                            matching[j] = false;
                        }
                    }
                    //count how many words match
                    
                    
                    for (int k = 0; k < nameParts.Length; k++)
                    {
                        
                        if (matching[k] == true)
                        {
                            matchCount++;
                            success = true;
                        }
                    }
                    matchValue[i] = matchCount;
                    matchCount = 0;
                }
                //bool success = allIsFalse(matching);
                if (success == false)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < nameParts.Length; j++)
                        {
                            string nameStore = dt.Rows[i]["name"].ToString();
                            if (nameStore.Contains(nameParts[j]) && !(nameStore.ToUpper().Contains("DEMO")))
                            {
                                matching[j] = true;

                            }
                            else
                            {
                                matching[j] = false;
                            }
                        }
                        //count how many words match

                        for (int k = 0; k < nameParts.Length; k++)
                        {

                            if (matching[k] == true)
                            {
                                matchCount++;
                            }
                        }
                        matchValue[i] = matchCount;
                        matchCount = 0;
                    }
                }
                //get highest amount of words that match (not great match if game isn't named well, but clean file names are necessary)
                for (int l = 0; l < matchValue.Length; l++)
                {

                    if (matchValue[l] > largestValue)
                    {
                        largestValue = matchValue[l];
                        largestIndex = l;
                    }
                }
                //get values for higest match and display
                name = dt.Rows[largestIndex]["name"].ToString();
                serial = dt.Rows[largestIndex]["serial"].ToString();
                region = dt.Rows[largestIndex]["region"].ToString();
                shortSerial = serial.Substring(serial.Length - 4);
                //string romPath = ConfigurationManager.AppSettings["romPath"];
                //string filename = romPath + "\\" + gameName;
                //string fileSize = sizeEstimate(filename);
                if (!File.Exists("\\Images\\" + shortSerial + ".jpg"))
                {
                    WebClient wc = new WebClient();
                    //download image if needed
                    try
                    {
                        if (region=="USA" || region=="ALL")
                        {
                            shortRegion = "US";
                        }
                        else if(region=="EUR")
                        {
                            shortRegion = "EN";
                        }
                        else if (region == "TWN")
                        {
                            shortRegion = "ZHTW";
                        }
                        else if (region == "JPN")
                        {
                            shortRegion = "JA";
                        }
                        else if (region == "KOR")
                        {
                            shortRegion = "KO";
                        }
                        else if (region == "ITA")
                        {
                            shortRegion = "IT";
                        }
                        else if (region == "FRA")
                        {
                            shortRegion = "FR";
                        }
                        else if (region == "GER")
                        {
                            shortRegion = "DE";
                        }
                        else if (region == "GER")
                        {
                            shortRegion = "DE";
                        }
                        else
                        {
                            shortRegion = "NA";
                        }
                        lblStatus.Text = "No boxart found locally, downloading";
                        if (shortRegion != "NA")
                        {

                            //Should move this to a secondary thread
                            Thread download = new Thread(new ThreadStart(downloadImage));
                            download.Start();
                            threadRunning = true;
                            do
                            {
                                Application.DoEvents();
                            } while (threadRunning == true);
                        }
                    }
                    catch
                    {
                        lblStatus.Text="Error downloading the box art or no box art found.";
                        Image image = Image.FromFile(Environment.CurrentDirectory + "\\Images\\3dsLogo.jpg");
                        pctBoxArt.Image = image;
                    }
                }
                if (shortRegion != "NA")
                {
                    Image image = Image.FromFile(Environment.CurrentDirectory + "\\Images\\" + shortSerial + ".jpg");
                    pctBoxArt.Image = image;
                }
                else
                {
                    Image image = Image.FromFile(Environment.CurrentDirectory + "\\Images\\3dsLogo.jpg");
                    pctBoxArt.Image = image;
                }
                lblStatus.Text = "Boxart download complete!";
                //make a confidence meter as the data we have isn't very clean and ww want to make sure the user knows
                confidence = (Convert.ToDouble(largestValue) / Convert.ToDouble(nameParts.Length)) * 100;
                confidence = Math.Round(confidence, 2);
                lblGameInfo.Text = "Name: " + name + "\r\n Region: " + region + "\r\n Serial: " + serial + "\r\n Match Confidence: " + confidence + "%";
                //lblGameInfo.Text = "Name: " + name + "\r\n Region: " + region + "\r\n Serial: " + serial +"\r\n File Size:"+ fileSize + "\r\n Match Confidence: "+confidence+"%";
                lblStatus.Text = "Information loaded for "+lstGamesList.Text;
            }
            catch (Exception ex)
            {
                //display an error
                MessageBox.Show(ex.ToString());
            }
        }
        public static bool allIsFalse(bool[] toCheck)
        {
            bool success = true;
            int countTrue = 0;
            for(int i=0;i<toCheck.Length; i++)
            {
                if(toCheck[i]==true)
                {
                    countTrue++;
                }
            }
            if(countTrue>0)
            {
                success = false;
            }
            return success;
        }
        private void downloadImage()
        {
            WebClient wc = new WebClient();
            try
            {
                wc.DownloadFile("http://art.gametdb.com/3ds/coverHQ/" + shortRegion + "/" + shortSerial + ".jpg", Environment.CurrentDirectory + "\\Temp\\" + shortSerial + ".jpg");
                //copy to working data folder                    
                File.Copy(Environment.CurrentDirectory + "\\Temp\\" + shortSerial + ".jpg", Environment.CurrentDirectory + "\\Images\\" + shortSerial + ".jpg", true);
                File.Delete(Environment.CurrentDirectory + "\\Temp\\" + shortSerial + ".jpg");
            }
            catch
            {
                try
                {
                    wc.DownloadFile("http://art.gametdb.com/3ds/coverM/" + shortRegion + "/" + shortSerial + ".jpg", Environment.CurrentDirectory + "\\Temp\\" + shortSerial + ".jpg");
                    //copy to working data folder                    
                    File.Copy(Environment.CurrentDirectory + "\\Temp\\" + shortSerial + ".jpg", Environment.CurrentDirectory + "\\Images\\" + shortSerial + ".jpg", true);
                    File.Delete(Environment.CurrentDirectory + "\\Temp\\" + shortSerial + ".jpg");
                }
                catch
                {

                    lblStatus.Text = "No box art found.";
                    shortRegion = "NA";
                }
            }
            threadRunning = false;
        }

        private void lstGamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int items = lstGamesList.SelectedItems.Count;
            items--;
            xmlDBRead(lstGamesList.SelectedItems[items].ToString());
            
        }

        private void frmMKEllie_Load(object sender, EventArgs e)
        {
            Image image = Image.FromFile(Environment.CurrentDirectory + "\\Images\\3dsLogo.jpg");
            pctBoxArt.Image = image;
            string gameName = string.Empty;
            string fileDate = "1/1/2001";
            string romPath = ConfigurationManager.AppSettings["romPath"];
            WebClient wc = new WebClient();
            //download latest XML from gametemp community db
            wc.DownloadFile("http://ptrk25.github.io/GroovyFX/database/community.xml", Environment.CurrentDirectory + "\\Temp\\3dsreleases.xml");
            //copy to working data folder
            try
            {
                File.Copy(Environment.CurrentDirectory + "\\Temp\\3dsreleases.xml", Environment.CurrentDirectory + "\\Data\\3dsreleases.xml", true);
                File.Delete(Environment.CurrentDirectory + "\\Temp\\3dsreleases.xml");
            }
            catch
            {
                FileInfo fi = new FileInfo(Environment.CurrentDirectory + "\\Data\\3dsreleases.xml");
                fileDate = fi.CreationTime.ToShortDateString();
                MessageBox.Show("Error downloading the latest game database, using the file download on " + fileDate);
            }

            //Get host IP address to give IP address to use a start
            string hostName = Dns.GetHostName(); 
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            txt3DSIP.Text = myIP;
            //save new path to app.config
            

            //read all game files into the list box
            if (romPath == "default")
            {
                romPath = Environment.CurrentDirectory + "\\Roms";
            }
            try {
                DirectoryInfo directory = new DirectoryInfo(romPath);
                FileInfo[] files = directory.GetFiles("*.cia");
                for (int i = 0; i < files.Length; i++)
                {
                    lstGamesList.Items.Add(files[i].ToString());
                }
                lblStatus.Text = "Loaded " + files.Length + " games to the list";
            }
            catch
            {
                lblStatus.Text = "Error getting game list or no .cia files found in rom path";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                tmrColorChange.Start();
            }
        }

        private void btnRomPath_Click(object sender, EventArgs e)
        {
            if (fbdRomPath.ShowDialog() == DialogResult.OK)
            {
                //save new path to app.config
                string ProviderKey = "romPath";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[ProviderKey].Value = fbdRomPath.SelectedPath.ToString();
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
                //load path and re-fill list box
                string romPath = ConfigurationManager.AppSettings["romPath"];
                lstGamesList.Items.Clear();
                DirectoryInfo directory = new DirectoryInfo(romPath);
                FileInfo[] files = directory.GetFiles("*.cia");
                for (int i = 0; i < files.Length; i++)
                {
                    lstGamesList.Items.Add(files[i].ToString());
                }
                lblStatus.Text = "Loaded " + files.Length + " games to the list";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                tmrColorChange.Start();
            }
        }
        private string sizeEstimate(string filename)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            FileInfo fi = new FileInfo(filename);
            double len = fi.Length;
            int order = 0;
            while (len >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                len = len / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            string result = String.Format("{0:0.##} {1}", len, sizes[order]);
            return result;
        }
        private void btnSendGame_Click(object sender, EventArgs e)
        {
            lstGamesList.Enabled = false;
            cboCountry.Enabled = false;
            txt3DSIP.Enabled = false;
            btnSendGame.Enabled = false;
            btnRomPath.Enabled = false;
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            string ProviderKey = "3dsIP";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[ProviderKey].Value = txt3DSIP.Text;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            string romPath = @"""" + ConfigurationManager.AppSettings["romPath"];
            if (lstGamesList.Items.Count > 0 && lstGamesList.Text != "" && myIP != txt3DSIP.Text)
            {
                try
                {
                    string gamesToSend = string.Empty;
                    int selectedCount = 0;
                    foreach (Object selectedItem in lstGamesList.SelectedItems)
                    {
                        if (selectedCount == 0)
                        {
                            gamesToSend = romPath + "\\" + selectedItem.ToString() + @"""";
                        }
                        else
                        {
                            gamesToSend = gamesToSend + " " + romPath + "\\" + selectedItem.ToString() + @"""";

                        }
                        selectedCount++;
                    }
                    string jarPath = @"""" + Environment.CurrentDirectory + @"\Sockfile\sockfile.jar""";
                    string argumensForJar = txt3DSIP.Text + " " + gamesToSend;
                    Process clientProcess = new Process();
                    string sendArguments = @"-cp . -jar " + jarPath + " " + argumensForJar;
                    int tempCount = 0;
                    int placeholder = 0;
                    clientProcess.StartInfo.FileName = "java";
                    clientProcess.StartInfo.Arguments = sendArguments;
                    clientProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    clientProcess.StartInfo.CreateNoWindow = true;
                    clientProcess.Start();
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    Process[] pname = Process.GetProcessesByName("java");
                    int javaRunningCount = pname.Length;
                    tmrColorChange.Start();
                    pname = Process.GetProcessesByName("java");
                    while (pname.Length >= javaRunningCount && pname.Length != 0)
                    {
                        if(tempCount==lstGamesList.SelectedItems.Count)
                        {
                            tempCount = 0;
                        }                        
                        lblStatus.Text = "Sending " + lstGamesList.SelectedItems[tempCount].ToString() + " To 2DS/3DS at " + txt3DSIP.Text;
                        Application.DoEvents();
                        pname = Process.GetProcessesByName("java");
                        placeholder++;
                        if (placeholder == 1000)
                        {
                            tempCount++;
                            placeholder = 0;
                        }
                    }
                    if (lstGamesList.SelectedItems.Count == 1)
                    {
                        lblStatus.Text = "Finished sending " + lstGamesList.Text + "  To 2DS/3DS at " + txt3DSIP.Text + ".  Check 2DS/3DS for details.";
                    }
                    else
                    {
                        lblStatus.Text = "Finished sending " + lstGamesList.SelectedItems.Count + " games To 2DS/3DS at " + txt3DSIP.Text + ".  Check 2DS/3DS for details.";
                    }

                }
                catch (Exception exc)
                {
                    lblStatus.Text = "Error sending file!";
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {                
                lblStatus.Text = "Please make sure you've set a vaild rom path, selected a game and changed the IP to the one shown on the 2DS/3DS";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                tmrColorChange.Start();
            }
            lstGamesList.Enabled = true;
            cboCountry.Enabled = true;
            txt3DSIP.Enabled = true;
            btnSendGame.Enabled = true;
            btnRomPath.Enabled = true;
        }
        private void tmrColorChange_Tick(object sender, EventArgs e)
        {
            lblStatus.ForeColor = System.Drawing.Color.Black;
        }

        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ProviderKey = "country";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[ProviderKey].Value = cboCountry.Text;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            //load path and re-fill list box
            string romPath = ConfigurationManager.AppSettings["country"];
            if (lstGamesList.SelectedItems.Count > 0)
            {
                int items = lstGamesList.SelectedItems.Count;
                items--;
                xmlDBRead(lstGamesList.SelectedItems[items].ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
