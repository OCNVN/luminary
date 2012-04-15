using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace Aprendiendo
{
	public partial class MenuBar
	{
		public MenuBar()
		{
			this.InitializeComponent();

			// Insert code required on object creation below this point.
		}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public static RoutedEvent VocabularioClickEvent =
            EventManager.RegisterRoutedEvent("VocabularioClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(MenuBar));

        public static RoutedEvent AdivinaClickEvent =
            EventManager.RegisterRoutedEvent("AdivinaClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(MenuBar));

        public static RoutedEvent ChatClickEvent =
            EventManager.RegisterRoutedEvent("ChatClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(MenuBar));

        public static RoutedEvent InterpreteClickEvent =
            EventManager.RegisterRoutedEvent("InterpreteClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(MenuBar));

        public static RoutedEvent ConfiguracionClickEvent =
            EventManager.RegisterRoutedEvent("ConfiguracionClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(MenuBar));

        public event RoutedEventHandler VocabularioClick
        {
            add { AddHandler(VocabularioClickEvent, value); }
            remove { RemoveHandler(VocabularioClickEvent, value); }
        }

        public event RoutedEventHandler AdivinaClick
        {
            add { AddHandler(AdivinaClickEvent, value); }
            remove { RemoveHandler(AdivinaClickEvent, value); }
        }

        public event RoutedEventHandler ChatClick
        {
            add { AddHandler(ChatClickEvent, value); }
            remove { RemoveHandler(ChatClickEvent, value); }
        }

        public event RoutedEventHandler InterpreteClick
        {
            add { AddHandler(InterpreteClickEvent, value); }
            remove { RemoveHandler(InterpreteClickEvent, value); }
        }

        public event RoutedEventHandler ConfiguracionClick
        {
            add { AddHandler(ConfiguracionClickEvent, value); }
            remove { RemoveHandler(ConfiguracionClickEvent, value); }
        }

        public void HandlerComun(object sender, RoutedEventArgs e)
        {
            if (sender == btnVocabulario)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = VocabularioClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == btnAdivina)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = AdivinaClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == btnChat)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = ChatClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == btnConfiguracion)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = ConfiguracionClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == btnInterprete)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = InterpreteClickEvent;
                RaiseEvent(ea);
            }
        }
	}
}