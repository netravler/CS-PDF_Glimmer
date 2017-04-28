using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using org.pdfbox.pdmodel;
using org.pdfbox.util;
using org.pdfbox.examples.pdmodel;
using org.pdfbox.exceptions;
using org.pdfbox.pdmodel.documentinterchange;
using org.pdfbox.pdmodel.interactive.documentnavigation.outline;
using org.pdfbox.pdmodel.interactive.documentnavigation.destination;
using org.pdfbox.pdfparser;
using org.pdfbox.pdmodel.encryption;
using org.pdfbox.pdfwriter;
using org.pdfbox.cos;
using org.pdfbox.pdmodel.font;

using java.lang;
using java.io;
using java.util;

using IKVM.Attributes;
using IKVM.Runtime;



namespace PDF_Glimmer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    

        public string parsePDF(string pdf_in, string txt_out)
        {
            //StreamWriter sw = new StreamWriter(txt_out, false);
            string txt;
            try
            {
                //sw.WriteLine();
                //sw.WriteLine(DateTime.Now.ToString());
                PDDocument doc = PDDocument.load(pdf_in); 
                PDFTextStripper stripper = new PDFTextStripper(); 
                //sw.Write(stripper.getText(doc));
                txt = stripper.getText(doc);
                return txt;
            } 
            finally
            {
                //sw.Close();
               // sw.Dispose();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = parsePDF(@textBox1.Text, @"c:\Leads_out.txt");
            }
            catch
            {
                richTextBox1.Text = "Noppers there was a problem";
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
