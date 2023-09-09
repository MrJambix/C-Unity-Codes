using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ResourceTrackerLibrary
{
	// Token: 0x020007F9 RID: 2041
	public class ResourceTracker
	{
		// Token: 0x0600346E RID: 13422
		public ResourceTracker()
		{
			this.nodes = new List<ResourceNode__5>();
			this.player = new Player__5(0f, 0f, 0f);
			this.ShowGUI();
		}

		// Token: 0x0600346F RID: 13423
		public void SetPlayerPosition(float x, float y, float z)
		{
			this.player = new Player__5(x, y, z);
		}

		// Token: 0x06003470 RID: 13424
		public float GetDistanceToNearestNode()
		{
			if (this.nodes.Count == 0)
			{
				throw new Exception("No resource nodes have been added.");
			}
			float shortestDistance = float.MaxValue;
			foreach (ResourceNode__5 node in from n in this.nodes
			where n.Type == this.selectedResource
			select n)
			{
				float distance = this.CalculateDistance(this.player, node);
				if (distance < shortestDistance)
				{
					shortestDistance = distance;
				}
			}
			return shortestDistance;
		}

		// Token: 0x060034C2 RID: 13506
		public void AddNode(ResourceNode__5 node)
		{
			this.nodes.Add(node);
		}

		// Token: 0x060034C5 RID: 13509
		private float CalculateDistance(Player__5 player, ResourceNode__5 node)
		{
			float num = player.X - node.X;
			float dy = player.Y - node.Y;
			float dz = player.Z - node.Z;
			return (float)Math.Sqrt((double)(num * num + dy * dy + dz * dz));
		}

		// Token: 0x060034C6 RID: 13510
		private void ShowGUI()
		{
			Form form = new Form
			{
				Text = "Resource Tracker",
				Size = new Size(300, 150)
			};
			Label label = new Label
			{
				Text = "Select Resource Type",
				Location = new Point(10, 10),
				AutoSize = true
			};
			form.Controls.Add(label);
			ComboBox resourceOptions = new ComboBox
			{
				Location = new Point(10, 30),
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			string[] minerals = new string[]
			{
				"Coal",
				"Copper Vein Small",
				"Copper Vein Large",
				"Iron Vein Small",
				"Iron Vein Large",
				"Gold Small",
				"Gold Large",
				"Silver Small",
				"Silver Large",
				"Platinum Small",
				"Platinum Large",
				"Palladium Small",
				"Palladium Large",
				"Feygold Small",
				"Feygold Large",
				"Crimsonite Small",
				"Crimsonite Large",
				"Celestium Small",
				"Celestium Large",
				"Azurium Small",
				"Azurium Large",
				"Mystril Small",
				"Mystril Large"
			};
			ComboBox.ObjectCollection items3 = resourceOptions.Items;
			object[] array = minerals;
			object[] items2 = array;
			items3.AddRange(items2);
			form.Controls.Add(resourceOptions);
			resourceOptions.SelectedIndexChanged += delegate(object sender, EventArgs e)
			{
				this.selectedResource = resourceOptions.SelectedItem.ToString();
			};
			Application.Run(form);
		}

		// Token: 0x04002D82 RID: 11650
		private List<ResourceNode__5> nodes;

		// Token: 0x04002D83 RID: 11651
		private Player__5 player;

		// Token: 0x04002D84 RID: 11652
		private string selectedResource = "";
	}
}
