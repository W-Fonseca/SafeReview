﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeReview.Objetos_Blue_Prism
{
    public class Check_Nome_Elemento
    {
        private List<string> nomes;

        public Check_Nome_Elemento()
        {
            nomes = new List<string>()
        {
            //HTML
            "a - ",
            "abbr - ",
            "acronym - ",
            "address - ",
            "app - ",
            "applet - ",
            "area - ",
            "article - ",
            "aside - ",
            "audio - ",
            "b - ",
            "base - ",
            "basefont - ",
            "bdi - ",
            "bdo - ",
            "bgsound - ",
            "big - ",
            "blink - ",
            "blockquote - ",
            "body - ",
            "br - ",
            "button - ",
            "canvas - ",
            "caption - ",
            "center - ",
            "cite - ",
            "code - ",
            "col - ",
            "colgroup - ",
            "comment - ",
            "datalist - ",
            "dd - ",
            "del - ",
            "details - ",
            "dfn - ",
            "dialog - ",
            "dir - ",
            "div - ",
            "dl - ",
            "dt - ",
            "em - ",
            "embed - ",
            "fieldset - ",
            "figcaption - ",
            "figure - ",
            "font - ",
            "footer - ",
            "form html tag - ",
            "frame - ",
            "frameset - ",
            "head - ",
            "header - ",
            "hr - ",
            "html - ",
            "hype - ",
            "i - ",
            "iframe - ",
            "img - ",
            "input - ",
            "ins - ",
            "isindex - ",
            "kbd - ",
            "keygen - ",
            "label - ",
            "legend - ",
            "li - ",
            "link - ",
            "listing - ",
            "main - ",
            "map - ",
            "mark - ",
            "marquee - ",
            "menu - ",
            "menuitem - ",
            "meta - ",
            "meter - ",
            "multicol - ",
            "nav - ",
            "nobr - ",
            "noembed - ",
            "noframes - ",
            "noscript - ",
            "object - ",
            "ol - ",
            "optgroup - ",
            "option - ",
            "output - ",
            "p - ",
            "param - ",
            "plaintext - ",
            "pre - ",
            "progress - ",
            "q - ",
            "rt - ",
            "ruby - ",
            "rp - ",
            "s - ",
            "samp - ",
            "script - ",
            "section - ",
            "select - ",
            "small - ",
            "sound - ",
            "source - ",
            "spacer - ",
            "span - ",
            "strong - ",
            "style - ",
            "sub - ",
            "summary - ",
            "table - ",
            "tbody - ",
            "td - ",
            "textarea - ",
            "tfoot - ",
            "th - ",
            "thead - ",
            "time - ",
            "title - ",
            "tr - ",
            "track - ",
            "tt - ",
            "u - ",
            "ul - ",
            "var - ",
            "video - ",
            "wbr - ",
            "xmp - ",
            
            // Application

            "layout - ",
            "border - ",
            "bulletdecorator - ",
            "canvas - ",
            "dockpanel - ",
            "expander - ",
            "grid - ",
            "gridsplitter - ",
            "groupbox - ",
            "panel - ",
            "resizegrip - ",
            "separator - ",
            "scrollbar - ",
            "scrollviewer - ",
            "stackpanel - ",
            "thumb - ",
            "viewbox - ",
            "virtualizingstackpanel - ",
            "window - ",
            "wrappanel - ",
            "buttons - ",
            "button - ",
            "repeatbutton - ",
            "data display - ",
            "datagrid - ",
            "listview - ",
            "treeview - ",
            "date display and selection - ",
            "calendar - ",
            "datepicker - ",
            "menus - ",
            "contextmenu - ",
            "menu - ",
            "toolbar - ",
            "selection - ",
            "checkbox - ",
            "combobox - ",
            "listbox - ",
            "radiobutton - ",
            "slider - ",
            "navigation - ",
            "frame - ",
            "hyperlink - ",
            "page - ",
            "navigationwindow - ",
            "tabcontrol - ",
            "dialog boxes - ",
            "openfiledialog - ",
            "printdialog - ",
            "savefiledialog - ",
            "user information - ",
            "accesstext - ",
            "label - ",
            "popup - ",
            "progressbar - ",
            "statusbar - ",
            "textblock - ",
            "tooltip - ",
            "documents - ",
            "documentviewer - ",
            "flowdocumentpageviewer - ",
            "flowdocumentreader - ",
            "flowdocumentscrollviewer - ",
            "stickynotecontrol - ",
            "input - ",
            "textbox - ",
            "richtextbox - ",
            "passwordbox - ",
            "media - ",
            "image - ",
            "mediaelement - ",
            "soundplayeraction - ",
            "digital ink - ",
            "inkcanvas - ",
            "inkpresenter - ",
            "control library - "
        };
        }

        public bool ValidarNome(string nome)
        {
            foreach (string nom in nomes)
            {

                if (nome.Contains(nom, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

            }
            return false;
            // return nomes.Contains(nome, StringComparer.OrdinalIgnoreCase);
        }
    }
}
