﻿using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagement
{
    public partial class FormTable : Form
    {
        
        public FormTable()
        {
            
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            List<Table> tables = new List<Table>();
            Point point = new Point(3, 30) ;
            //3 111 224


            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From [Table]";
            DataProvider.Instance.con.Open();
            cmd.Connection = DataProvider.Instance.con;


            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tables.Add(new Table(Int32.Parse(dr["ID"].ToString()), dr["Name"].ToString(), dr["Status"].ToString()));
            }
            dr.Close();

            //pn_Table 
            int j = 0;
            for(int i=0;i<tables.Count;i++)
            {
                Button btn = new Button();
                btn.Size=new Size(90, 40);
                btn.Font = new System.Drawing.Font(button1.Font.FontFamily, 12);
                if (tables[i].status=="Online")
                    btn.BackColor = System.Drawing.Color.Red;
                btn.Text = tables[i].name;
                if(point.X + 90 > pn_Table.Width)
                {
                    point.X = 3; point.Y += 50;
                }
                btn.Location = point;
                pn_Table.Controls.Add(btn);
                point.X += 90 + 10;
             
            }
            

             
        }


        

    }
}
