using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace RoRInvest
{
    public class helper
    {
        //secara otomatis merubah keyboard ke numerical untuk textbox tertentu
        public void setInputScope(TextBox textBoxControl)
        {
            InputScopeNameValue type = InputScopeNameValue.Number;
            textBoxControl.InputScope = new InputScope()
            {
                Names ={new InputScopeName(){NameValue=type}
                }

            };
        }
    }
}
