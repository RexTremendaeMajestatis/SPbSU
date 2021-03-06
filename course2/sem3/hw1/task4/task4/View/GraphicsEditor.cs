﻿namespace Task4
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Class of graphics editor form
    /// </summary>
    public partial class GraphicsEditor : Form
    {
        private Logic logic = new Logic();
        
        public GraphicsEditor()
        {   
            this.InitializeComponent();
            this.UndoButton.Enabled = false;
            this.RedoButton.Enabled = false;
            this.DeleteLineButton.Enabled = false;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            this.logic.Undo();
            this.UndoButton.Enabled = this.logic.AllowUndo;
            this.RedoButton.Enabled = this.logic.AllowRedo;
            this.DrawArea.Invalidate();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            this.logic.Redo();
            this.UndoButton.Enabled = this.logic.AllowUndo;
            this.RedoButton.Enabled = this.logic.AllowRedo;
            this.DrawArea.Invalidate();
        }

        private void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            this.logic.MouseDown(e);
            this.DrawArea.Invalidate();
        }

        private void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            this.logic.MouseUp(e);
            this.DeleteLineButton.Enabled = this.logic.AllowDeletion;
            this.UndoButton.Enabled = this.logic.AllowUndo;
            this.DrawArea.Invalidate();
        }

        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            this.logic.MouseMove(e);
            this.DrawArea.Invalidate();
        }

        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            this.logic.Paint(e);
        }

        private void DeleteLineButton_Click(object sender, EventArgs e)
        {
            this.logic.DeleteLine();
            this.DeleteLineButton.Enabled = this.logic.AllowDeletion;
            this.DrawArea.Invalidate();
        }

        private void DrawLinesButton_Click(object sender, EventArgs e)
        {
            this.logic.DrawLines();
            this.DrawLinesButton.BackColor = Color.Gray;
            this.SelectLinesButton.BackColor = Color.Empty;
        }

        private void SelectLinesButton_Click(object sender, EventArgs e)
        {
            this.logic.SelectLines();
            this.DrawLinesButton.BackColor = Color.Empty;
            this.SelectLinesButton.BackColor = Color.Gray;
        }
    }
}
