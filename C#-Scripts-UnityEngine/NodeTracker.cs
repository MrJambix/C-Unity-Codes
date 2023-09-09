using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ResourceTrackerLibrary
{
	// Token: 0x020007F9 RID: 2041
	public class ResourceTracker
	{
		// Token: 0x0600346E RID: 13422
		public ResourceTracker()
		{
			this.nodes = new List<ResourceNode__3>();
			this.player = new Player__3(0f, 0f, 0f);
		}

		// Token: 0x06003470 RID: 13424
		public void SetPlayerPosition(float x, float y, float z)
		{
			this.player = new Player__3(x, y, z);
		}

		// Token: 0x06003471 RID: 13425
		public float GetDistanceToNearestNode()
		{
			if (this.nodes.Count == 0)
			{
				throw new Exception("No resource nodes have been added.");
			}
			float shortestDistance = float.MaxValue;
			foreach (ResourceNode__3 node in this.nodes)
			{
				float distance = this.CalculateDistance(this.player, node);
				if (distance < shortestDistance)
				{
					shortestDistance = distance;
				}
			}
			return shortestDistance;
		}

		// Token: 0x0600349B RID: 13467
		public void AddNode(ResourceNode__3 node)
		{
			this.nodes.Add(node);
		}

		// Token: 0x0600349E RID: 13470
		private float CalculateDistance(Player__3 player, ResourceNode__3 node)
		{
			float num = player.X - node.X;
			float dy = player.Y - node.Y;
			float dz = player.Z - node.Z;
			return (float)Math.Sqrt((double)(num * num + dy * dy + dz * dz));
		}

		// Token: 0x0600349F RID: 13471
		public void ShowDistanceToNearestNode()
		{
			float distance = this.GetDistanceToNearestNode();
			Form form = new Form();
			form.Width = 300;
			form.Height = 150;
			form.Text = "Resource Tracker";
			Label label = new Label();
			label.Text = string.Format("Distance to nearest node: {0} units", distance);
			label.Dock = DockStyle.Fill;
			label.TextAlign = ContentAlignment.MiddleCenter;
			form.Controls.Add(label);
			form.ShowDialog();
		}

		// Token: 0x04002D6F RID: 11631
		private List<ResourceNode__3> nodes;

		// Token: 0x04002D70 RID: 11632
		private Player__3 player;
	}
}
