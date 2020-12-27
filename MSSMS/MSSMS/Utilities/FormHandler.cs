using MSSMS.Enums;
using MSSMS.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSMS
{
    public class FormHandler
    {
        Panel mainContainer = null;
        Form currentMainContent = null;
        public static Form parentForm;
        public static String parentFormName;
        public static ChildFormType childFormType = ChildFormType.NULL;
        public static Object newObject = null;

        public FormHandler(Panel mainContainer)
        {
            this.mainContainer = mainContainer;
        }

        public void changeMainContent(Form mainContent)
        {
            if(currentMainContent != null)
            {
                currentMainContent.Close();
            }
            this.currentMainContent = mainContent;
            mainContent.TopLevel = false;
            mainContent.FormBorderStyle = FormBorderStyle.None;
            mainContent.Dock = DockStyle.Fill;
            mainContainer.Controls.Add(mainContent);
            mainContent.BringToFront();
            mainContent.Show();  
            
        }
        
        public static void loadLobby(String parentName, Form parent, string childFormName)
        {
            parentForm = parent;
            parentFormName = parentName;

            bool isActive = false;

            foreach (Form activeChildForm in Application.OpenForms)
            {
                if (activeChildForm.Name == childFormName)
                {
                    isActive = true;
                    activeChildForm.BringToFront();
                    activeChildForm.WindowState = FormWindowState.Normal;
                }
            }

            if (isActive == false)
            {
                var newChildForm = Activator.CreateInstance(Type.GetType("MSSMS." + childFormName)) as Form;
                newChildForm.Show();            
            }
        }

        public static void openChildForm(String parentName, Form parent, string childFormName, ChildFormType childType, Object objectToUpdate)
        {
            parentForm = parent;
            parentFormName = parentName;

            bool isActive = false;
            Form formToClose = null;

            foreach (Form activeChildForm in Application.OpenForms)
            {
                if (activeChildForm.Name == childFormName)
                {
                    if (childType == childFormType)
                    {
                        if (childType == ChildFormType.ADD)
                        {
                            isActive = true;
                            activeChildForm.BringToFront();
                            activeChildForm.WindowState = FormWindowState.Normal;
                            break;
                        }
                        else if (childType == ChildFormType.UPDATE)
                        {
                            //activeChildForm.Close();
                            formToClose = activeChildForm;
                            isActive = false;
                            break;
                        }
                    }
                    else
                    {
                        //activeChildForm.Close();
                        formToClose = activeChildForm;
                        isActive = false;
                    }
                }
                else
                {
                    formToClose = null;
                    isActive = false;
                }
            }

            if (isActive == false)
            {

                childFormType = childType;
                newObject = objectToUpdate;

                if (formToClose != null)
                {
                    formToClose.Close();
                }

                var newChildForm = Activator.CreateInstance(Type.GetType("MSSMS." + childFormName)) as Form;
                newChildForm.Show();
            }
        }
    }
}
