using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace EthyrialDPS
{
    public class DamageAndExpTracker
    {
        public float TotalDamage { get; private set; } = 0f;
        public float TotalExp { get; private set; } = 0f;

        public void RegisterDamage(float damage)
        {
            TotalDamage += damage;
        }

        public void RegisterExp(float exp)
        {
            TotalExp += exp;
        }
    }

    public class DPSDisplay : Form
    {
        private DamageAndExpTracker tracker;
        private Label dpsLabel;

        public DPSDisplay(DamageAndExpTracker tracker)
        {
            this.tracker = tracker;
            this.Width = 200;
            this.Height = 100;
            this.Text = "Ethyrial DPS Display";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            dpsLabel = new Label
            {
                Font = new Font("Arial", 12),
                Text = "DPS: 0",
                Location = new Point(10, 10),
                Size = new Size(180, 30)
            };

            this.Controls.Add(dpsLabel);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            RefreshDPS();
        }

        private void RefreshDPS()
        {
            // For demonstration purposes, we'll just use TotalDamage directly.
            // In a real scenario, you'd compute DPS by dividing damage over elapsed time.
            dpsLabel.Text = $"DPS: {tracker.TotalDamage}";
        }

        public static void LaunchDPSDisplay(DamageAndExpTracker tracker)
        {
            Application.Run(new DPSDisplay(tracker));
        }
    }

    public class CreditsDisplay : Form
    {
        public CreditsDisplay()
        {
            this.Width = 300;
            this.Height = 150;
            this.Text = "Credits";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            Label creditsLabel = new Label
            {
                Font = new Font("Arial", 10),
                Text = "Created by: MrJambix on Discord or Jambix in-game\n\nIf you are utilizing this, You Acknowledge MrJambix is your Daddy! Just Kidding! Check MrJambix out on Twitch.tv/MrJambix!\n\nThanks to Bardcore for his initial contribution and expertise.",
                Location = new Point(10, 10),
                Size = new Size(280, 130)
            };

            this.Controls.Add(creditsLabel);
        }

        public static void LaunchCreditsDisplay()
        {
            Application.Run(new CreditsDisplay());
        }
    }

    public class SkillTracker
    {
        public Dictionary<string, float> Skills = new Dictionary<string, float>
        {
            {"Alchemy", 0.0f},
            {"Blacksmithing", 0.0f},
            {"Cooking", 0.0f},
            {"Fishing", 0.0f},
            {"Herbalism", 0.0f},
            {"Jewelcrafting", 0.0f},
            {"Leatherworking", 0.0f},
            {"Mining", 0.0f},
            {"Skinning", 0.0f},
            {"Tailoring", 0.0f},
            {"Woodcutting", 0.0f},
            {"Woodwork", 0.0f}
        };

        public void UpdateSkill(string skillName, float percentage)
        {
            if (Skills.ContainsKey(skillName))
                Skills[skillName] = percentage;
        }
    }

    public class SkillProgressDisplay : Form
    {
        private SkillTracker tracker;
        private Dictionary<string, ProgressBar> skillProgressBars = new Dictionary<string, ProgressBar>();

        public SkillProgressDisplay(SkillTracker tracker)
        {
            this.tracker = tracker;
            this.Width = 300;
            this.Height = 500;
            this.Text = "Ethyrial Skill Tracker";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            int yOffset = 10;
            foreach (var skill in tracker.Skills)
            {
                var skillLabel = new Label
                {
                    Font = new Font("Arial", 10),
                    Text = skill.Key,
                    Location = new Point(10, yOffset),
                    Size = new Size(100, 20)
                };

                var progressBar = new ProgressBar
                {
                    Location = new Point(120, yOffset),
                    Size = new Size(150, 20),
                    Value = (int)(skill.Value * 100)
                };

                skillProgressBars[skill.Key] = progressBar;

                this.Controls.Add(skillLabel);
                this.Controls.Add(progressBar);

                yOffset += 30;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            RefreshProgress();
        }

        private void RefreshProgress()
        {
            foreach (var skill in tracker.Skills)
            {
                if (skillProgressBars.ContainsKey(skill.Key))
                {
                    skillProgressBars[skill.Key].Value = (int)(skill.Value * 100);
                }
            }
        }

        public static void LaunchSkillTracker(SkillTracker tracker)
        {
            Application.Run(new SkillProgressDisplay(tracker));
        }
    }
}
