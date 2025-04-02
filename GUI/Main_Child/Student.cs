using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Student: Form
    {
        public Student()
        {
            InitializeComponent();
        }
       
        
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        PrintDocument printDocument = new PrintDocument();
        int rowIndex = 0;
        int pageNumber = 1;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Setup
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            // Optional Preview
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDocument;
            ppd.ShowDialog();

        }
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Times New Roman", 20, FontStyle.Bold);
            Font cellFont = new Font("Times New Roman", 15);
            Font smallFont = new Font("Times New Roman", 13);

            int y = 100;
            int x = e.MarginBounds.Left;
            int tableWidth = e.MarginBounds.Width;
            int colCount = dgvStudent.Columns.Count;

            // AUTO-FIT COLUMN WIDTH
            int colWidth = tableWidth / colCount;

            // --- Header ---
            string title = "Students List";
            string broText = "BRO ENGLISH";
            string dateText = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            //Draw "BRO ENGLISH" top-right
            e.Graphics.DrawString(broText, headerFont, Brushes.Black, e.MarginBounds.Right - e.Graphics.MeasureString(broText, headerFont).Width, y - 70);

            // Centered Title
            SizeF titleSize = e.Graphics.MeasureString(title, headerFont);
            e.Graphics.DrawString(title, headerFont, Brushes.Black, e.MarginBounds.Left + (tableWidth - titleSize.Width) / 2, y - 50);

            // Print Date below title
            SizeF dateSize = e.Graphics.MeasureString(dateText, smallFont);
            e.Graphics.DrawString(dateText, smallFont, Brushes.Black, e.MarginBounds.Left + (tableWidth - dateSize.Width) / 2, y - 25);

            // Draw Column Headers 
            for (int j = 0; j < colCount; j++)
            {
                e.Graphics.DrawRectangle(Pens.Black, x, y, colWidth, 40);
                e.Graphics.DrawString(dgvStudent.Columns[j].HeaderText, cellFont, Brushes.Black, new RectangleF(x, y, colWidth, 40));
                x += colWidth;
            }

            y += 40;
            x = e.MarginBounds.Left;

            // Draw Rows
            while (rowIndex < dgvStudent.Rows.Count)
            {
                DataGridViewRow row = dgvStudent.Rows[rowIndex];
                if (!row.IsNewRow)
                {
                    x = e.MarginBounds.Left;
                    for (int j = 0; j < colCount; j++)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, x, y, colWidth, 40);
                        e.Graphics.DrawString(row.Cells[j].FormattedValue?.ToString() ?? "", cellFont, Brushes.Black, new RectangleF(x, y, colWidth, 40));
                        x += colWidth;
                    }
                    y += 40;
                }
                rowIndex++;

                // --- Auto Page Break ---
                if (y > e.MarginBounds.Bottom - 60)
                {
                    e.HasMorePages = true;
                    pageNumber++;
                    return;
                }
            }

            //Footer --- Page Number bottom right
            string pageNumText = $"Page {pageNumber}";
            e.Graphics.DrawString(pageNumText, smallFont, Brushes.Black, e.MarginBounds.Right - e.Graphics.MeasureString(pageNumText, smallFont).Width, e.MarginBounds.Bottom + 20);

            // Reset for next
            rowIndex = 0;
            pageNumber = 1;
            e.HasMorePages = false;
        }

        private void guna2dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Student_Load(object sender, EventArgs e)
        {
            dgvStudent.Rows.Add("1", "Bro A", "90");
            dgvStudent.Rows.Add("2", "Bro B", "85");
            dgvStudent.Rows.Add("3", "Bro C", "100");
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
