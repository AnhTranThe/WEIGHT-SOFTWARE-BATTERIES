using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1.Class
{
 public class Resize_function
    {
        List<System.Drawing.Rectangle> _arr_control_storage = new List<System.Drawing.Rectangle>();
        private bool showRowHeader = false;
         public Resize_function(Form Formcall)
    {
        form = Formcall; //the calling form
        form_size = Formcall.ClientSize;
        font_size = Formcall.Font.Size;

    }
        
     
     
         private Form form { get; set; }
         private float font_size { get; set; }
         private System.Drawing.SizeF form_size { get; set; }



         public void get_initial_size() // lấy thông số ban đầu
         {
             var controls = get_all_controls(form);//call the enumerator
             foreach (Control control in controls) //Loop through the controls
             {
                 _arr_control_storage.Add(control.Bounds); //saves control bounds/dimension    
        
                 //If you have datagridview
                 if (control.GetType() == typeof(DataGridView))
                     dgv_Column_Adjust(((DataGridView)control), showRowHeader);
             }
         }

         private static IEnumerable<Control> get_all_controls(Control c)
         {
             return c.Controls.Cast<Control>().SelectMany(item =>
                 get_all_controls(item)).Concat(c.Controls.Cast<Control>()).Where(control =>
                 control.Name != string.Empty);
         }

         public void resize() //Set the resize
         {
             double form_ratio_width = (double)form.ClientSize.Width / (double)form_size.Width; //ratio could be greater or less than 1
             double form_ratio_height = (double)form.ClientSize.Height / (double)form_size.Height; // this one too
             var _controls = get_all_controls(form); //reenumerate the control collection
             int _pos = -1;//do not change this value unless you know what you are doing
             foreach (Control control in _controls)
             {
                 // do some math calc
                 _pos += 1;//increment by 1;
                 System.Drawing.Size _controlSize = new System.Drawing.Size((int)(_arr_control_storage[_pos].Width * form_ratio_width),
                     (int)(_arr_control_storage[_pos].Height * form_ratio_height)); //use for sizing

                 System.Drawing.Point _controlposition = new System.Drawing.Point((int)
                 (_arr_control_storage[_pos].X * form_ratio_width), (int)(_arr_control_storage[_pos].Y * form_ratio_height));//use for location

                 //set bounds
                 control.Bounds = new System.Drawing.Rectangle(_controlposition, _controlSize); //Put together

                 //Assuming you have a datagridview inside a form()
                 //if you want to show the row header, replace the false statement of 
                 //showRowHeader on top/public declaration to true;

                 if (control.GetType() == typeof(DataGridView))
                     dgv_Column_Adjust(((DataGridView)control), showRowHeader);


                 //Font AutoSize
                 control.Font = new System.Drawing.Font(form.Font.FontFamily,
                  (float)(((Convert.ToDouble(font_size) * form_ratio_width) / 1.3) +
                   ((Convert.ToDouble(font_size) * form_ratio_height) / 1.3)));

             }
         }


         private void dgv_Column_Adjust(DataGridView dgv, bool showRowHeader) // nếu có datagridview
         //and want to resize the column base on its dimension.
         {
             int intRowHeader = 0;
             const int Hscrollbarwidth = 5;
             if (showRowHeader)
                 intRowHeader = dgv.RowHeadersWidth;
             else
                 dgv.RowHeadersVisible = false;

             for (int i = 0; i < dgv.ColumnCount; i++)
             {
                 if (dgv.Dock == DockStyle.Fill) //dành cho trường hợp datagridview là dock 
                     dgv.Columns[i].Width = ((dgv.Width - intRowHeader) / dgv.ColumnCount);
                 else
                     dgv.Columns[i].Width = ((dgv.Width - intRowHeader - Hscrollbarwidth) / dgv.ColumnCount);
             }
         } 





    }
}
