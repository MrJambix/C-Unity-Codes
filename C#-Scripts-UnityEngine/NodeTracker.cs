using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NodeTracker
{
    public class Player
    {
        public float X, Y, Z;

        public Player(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class ResourceNode
    {
        public float X, Y, Z;
        public string Type;  // e.g., "Copper Vein", "Iron Vein", "Coal", etc.

        public ResourceNode(float x, float y, float z, string type)
        {
            X = x;
            Y = y;
            Z = z;
            Type = type;
        }
    }

    public class ResourceTracker : Form
    {
        private Player player;
        private List<ResourceNode> nodes;

        // GUI Components
        private ComboBox mineralComboBox, herbalismComboBox, woodCuttingComboBox, sizeComboBox;
        private CheckBox trackMineralCheckBox, trackHerbCheckBox, trackTreeCheckBox, showArrowCheckBox;
        private Label distanceLabel;
        private Button startButton;

        public ResourceTracker()
        {
            this.nodes = new List<ResourceNode>();
            this.player = new Player(0, 0, 0);

            // GUI Initialization
            InitializeComponents();

            // This timer will keep updating the GUI
            Timer updateTimer = new Timer();
            updateTimer.Interval = 1000;  // 1 second
            updateTimer.Tick += (s, e) => Update();
            updateTimer.Start();
        }

        private void InitializeComponents()
        {
            this.distanceLabel = new Label() { Location = new Point(10, 10), Width = 200 };
            this.Controls.Add(distanceLabel);

            this.mineralComboBox = new ComboBox() { Location = new Point(10, 40), Width = 100 };
            this.mineralComboBox.Items.AddRange(new string[] {
                "Copper", "Iron", "Coal", "Gold", "Silver",
                "Platinum", "Palladium", "Feygold", "Crimsonite",
                "Celestium", "Azurium", "Mystril"
            });
            this.Controls.Add(mineralComboBox);

            this.herbalismComboBox = new ComboBox() { Location = new Point(120, 40), Width = 100 };
            this.herbalismComboBox.Items.AddRange(new string[] {
                "Hemp", "Rinthistle", "Redban", "Sunthistle", "FrostFlower",
                "Nepbloom", "Minweed", "Oxbloom", "Ginshade", "Aetherthistle",
                "Starstem", "Flax", "Wistera", "Cotton", "Arcanebloom",
                "Elvenbloom", "Potato"
            });
            this.Controls.Add(herbalismComboBox);

            this.woodCuttingComboBox = new ComboBox() { Location = new Point(230, 40), Width = 100 };
            this.woodCuttingComboBox.Items.AddRange(new string[] {
                "Acacia Tree", "Wispwood Tree", "Staroak Tree", "Aetherbark Tree"
            });
            this.Controls.Add(woodCuttingComboBox);

            this.trackMineralCheckBox = new CheckBox() { Location = new Point(10, 70), Text = "Track Minerals" };
            this.Controls.Add(trackMineralCheckBox);

            this.trackHerbCheckBox = new CheckBox() { Location = new Point(120, 70), Text = "Track Herbs" };
            this.Controls.Add(trackHerbCheckBox);

            this.trackTreeCheckBox = new CheckBox() { Location = new Point(230, 70), Text = "Track Trees" };
            this.Controls.Add(trackTreeCheckBox);

            this.showArrowCheckBox = new CheckBox() { Location = new Point(10, 100), Text = "Show Arrow" };
            this.Controls.Add(showArrowCheckBox);

            this.sizeComboBox = new ComboBox() { Location = new Point(10, 130), Width = 100 };
            this.sizeComboBox.Items.AddRange(new string[] { "Small", "Medium", "Large" });
            this.sizeComboBox.SelectedIndexChanged += (s, e) => ResizeForm(sizeComboBox.SelectedItem.ToString());
            this.Controls.Add(sizeComboBox);

            this.startButton = new Button() { Location = new Point(10, 160), Text = "Start" };
            this.startButton.Click += (s, e) => Update();
            this.Controls.Add(startButton);

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Size = new Size(350, 250);
        }

        private void ResizeForm(string size)
        {
            switch (size)
            {
                case "Small":
                    this.Size = new Size(200, 150);
                    break;
                case "Medium":
                    this.Size = new Size(350, 250);
                    break;
                case "Large":
                    this.Size = new Size(500, 350);
                    break;
            }
        }

        private ResourceNode GetClosestResourceNode()
        {
            // Implement the logic to find the closest resource node based on the selected options
            ResourceNode closestNode = null;
            double minDistance = double.MaxValue;

            foreach (ResourceNode node in nodes)
            {
                if (IsResourceTypeSelected(node.Type))
                {
                    double distance = GetDistance(player, node);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestNode = node;
                    }
                }
            }

            return closestNode;
        }

        private bool IsResourceTypeSelected(string nodeType)
        {
            string selectedMineral = mineralComboBox.SelectedItem.ToString();
            if ((trackMineralCheckBox.Checked && nodeType.Contains(selectedMineral)) ||
                (trackHerbCheckBox.Checked && herbalismComboBox.SelectedItem.ToString() == nodeType) ||
                (trackTreeCheckBox.Checked && woodCuttingComboBox.SelectedItem.ToString() == nodeType))
            {
                return true;
            }

            return false;
        }

        private double GetDistance(Player p, ResourceNode r)
        {
            double dx = p.X - r.X;
            double dy = p.Y - r.Y;
            double dz = p.Z - r.Z;

            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public static void Main()
        {
            Application.Run(new ResourceTracker());
        }
    }
}
