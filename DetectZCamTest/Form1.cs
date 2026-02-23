using System.Runtime.CompilerServices;

namespace DetectZCamTest
{
    public partial class Form1 : Form
    {
        private Panel overlayPanel;
        private ProgressBar spinner;

        public Form1()
        {
            InitializeComponent();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
        }

        private int CenterX(Control parent, Control child)
        {
            return (parent.ClientSize.Width - child.Width) / 2;
        }

        private void InitializeSpinnerOverlay()
        {
            overlayPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(120, Color.Gray), // semi-transparent
                Visible = false
            };

            spinner = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                Size = new Size(200, 20)
            };

            overlayPanel.Controls.Add(spinner);
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront();

            overlayPanel.Resize += (s, e) =>
            {
                spinner.Left = (overlayPanel.Width - spinner.Width) / 2;
                spinner.Top = (overlayPanel.Height - spinner.Height) / 2;
            };
        }

        private void ShowSpinner()
        {
            overlayPanel.Visible = true;
            overlayPanel.BringToFront();
        }

        private void HideSpinner()
        {
            overlayPanel.Visible = false;
        }
        private void SetUiEnabled(bool enabled)
        {
            foreach (Control c in this.Controls)
            {
                if (c != overlayPanel)
                    c.Enabled = enabled;
            }
        }

        private async Task ScanCamerasAsync()
        {
            grpBoxCameras.Enabled = false;
            grpBoxCameras.Controls.Clear();

            ShowSpinner();
            SetUiEnabled(false);
            grpBoxCameras.Controls.Clear();


            try
            {
                var ips = await Task.Run(() => MDNSNative.DiscoverIPs());

                int y = 25;
                int index = 0;

                foreach (var ip in ips)
                {
                    var chk = new CheckBox
                    {
                        Name = $"chkCamera_{index}",
                        Text = $"ZCam @ {ip}",
                        AutoSize = true,
                        ForeColor = Color.White,
                        BackColor = Color.Transparent
                    };

                    // Important: add first so Width is calculated
                    grpBoxCameras.Controls.Add(chk);

                    chk.Location = new Point(
                        CenterX(grpBoxCameras, chk),
                        y
                    );

                    y += chk.Height + 8;
                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Discovery failed: {ex.Message}");
            }
            finally
            {
                grpBoxCameras.Enabled = true;
                HideSpinner();
                SetUiEnabled(true);
            }
        }

        private async void Scan_OnClick(object sender, EventArgs e)
        {
            InitializeSpinnerOverlay();
            await ScanCamerasAsync();
        }
    }
}
