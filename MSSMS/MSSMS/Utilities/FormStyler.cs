using MSSMS.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSMS
{
    public class FormStyler
    {
        Form form = null;

        public FormStyler( Form form)
        {
            this.form = form;
            InitializeStyles();            
        }

        private void InitializeStyles()
        {
            //initialize sidebar styles
            stylizeSidebar();
            hideAllSubmenus();
        }

        public void sidebarButton_Click (Button sidebarButton, Panel submenu, Button submenuButton)
        {
            if (submenu == null && submenuButton == null)
            {
                stylizeSidebar();
                hideAllSubmenus();
                sidebarButton.BackColor = Color.FromArgb(66, 66, 66);
            } 
            else if (submenu != null && submenuButton == null)
            {
                stylizeSidebar();
                sidebarButton.BackColor = Color.FromArgb(66, 66, 66);
                if(submenu.Visible == false)
                {
                    submenu.Visible = true;
                    hideAllSubmenusExcept(submenu);
                } 
                else
                {
                    //hideAllSubmenus();
                }
            } 
            else
            {
                stylizeSidebar();
                sidebarButton.BackColor = Color.FromArgb(66, 66, 66);
                submenuButton.BackColor = Color.FromArgb(97, 97, 97);
                submenuButton.Image = Resources.arrow;
                submenuButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        //sidebar methods
        private void stylizeSidebar()
        {
         
            foreach (Control formControl in form.Controls)
            {
                if (formControl is Panel && formControl.Name == "panelSidebarContainer")
                {
                    foreach (Control sidebarContainerItem in formControl.Controls)
                    {
                        if (sidebarContainerItem is Panel && sidebarContainerItem.Name == "panelSidebar")
                        {
                            foreach (Control sidebarItem in sidebarContainerItem.Controls)
                            {
                                //sidebar main buttons
                                if (sidebarItem is Button)
                                {
                                    Button sidebarButton = sidebarItem as Button;
                                    sidebarButton.BackColor = Color.FromArgb(37, 35, 38);
                                    sidebarButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(117, 117, 117);
                                    sidebarButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(97, 97, 97);
                                }

                                //submenus
                                if (sidebarItem is Panel && sidebarItem.Name != "panelFooter")
                                {
                                    //submenu buttons
                                    foreach (Control submenuItem in sidebarItem.Controls)
                                    {
                                        if (submenuItem is Button)
                                        {
                                            Button submenuButton = submenuItem as Button;
                                            submenuButton.BackColor = Color.FromArgb(50, 49, 51);
                                            submenuButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(117, 117, 117);
                                            submenuButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(97, 97, 97);
                                            submenuButton.Image = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void hideAllSubmenus()
        {
            foreach (Control formControl in form.Controls)
            {
                if (formControl is Panel && formControl.Name == "panelSidebarContainer")
                {
                    foreach (Control sidebarContainerItem in formControl.Controls)
                    {
                        if (sidebarContainerItem is Panel && sidebarContainerItem.Name == "panelSidebar")
                        {
                            foreach (Control sidebarItem in sidebarContainerItem.Controls)
                            {
                                //submenus
                                if (sidebarItem is Panel && sidebarItem.Name != "panelFooter")
                                {
                                    Panel submenu = sidebarItem as Panel;
                                    submenu.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void hideAllSubmenusExcept(Panel submenu)
        {
            foreach (Control formControl in form.Controls)
            {
                if (formControl is Panel && formControl.Name == "panelSidebarContainer")
                {
                    foreach (Control sidebarContainerItem in formControl.Controls)
                    {
                        if (sidebarContainerItem is Panel && sidebarContainerItem.Name == "panelSidebar")
                        {
                            foreach (Control sidebarItem in sidebarContainerItem.Controls)
                            {
                                //submenus
                                if (sidebarItem is Panel && sidebarItem.Name != "panelFooter" && sidebarItem.Name !=submenu.Name)
                                {
                                    if (sidebarItem.Visible == true)
                                    {
                                        Panel submenuToHide = sidebarItem as Panel;
                                        submenuToHide.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
