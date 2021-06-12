using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace Aprendiendo.controles.teclado
{
	public partial class Teclado
	{
        public static RoutedEvent QClickEvent =
            EventManager.RegisterRoutedEvent("QClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent WClickEvent =
            EventManager.RegisterRoutedEvent("WClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent EClickEvent =
            EventManager.RegisterRoutedEvent("EClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));
        
        public static RoutedEvent RClickEvent =
            EventManager.RegisterRoutedEvent("RClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent TClickEvent =
            EventManager.RegisterRoutedEvent("TClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent YClickEvent =
            EventManager.RegisterRoutedEvent("YClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent UClickEvent =
            EventManager.RegisterRoutedEvent("UClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent IClickEvent =
            EventManager.RegisterRoutedEvent("IClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent OClickEvent =
            EventManager.RegisterRoutedEvent("OClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent PClickEvent =
            EventManager.RegisterRoutedEvent("PClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent AClickEvent =
            EventManager.RegisterRoutedEvent("AClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent SClickEvent =
            EventManager.RegisterRoutedEvent("SClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent DClickEvent =
            EventManager.RegisterRoutedEvent("DClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent FClickEvent =
            EventManager.RegisterRoutedEvent("FClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent GClickEvent =
            EventManager.RegisterRoutedEvent("GClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent HClickEvent =
            EventManager.RegisterRoutedEvent("HClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent JClickEvent =
            EventManager.RegisterRoutedEvent("JClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent KClickEvent =
            EventManager.RegisterRoutedEvent("KClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent LClickEvent =
            EventManager.RegisterRoutedEvent("LClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent ZClickEvent =
            EventManager.RegisterRoutedEvent("ZClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent XClickEvent =
            EventManager.RegisterRoutedEvent("XClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent CClickEvent =
            EventManager.RegisterRoutedEvent("CClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent VClickEvent =
            EventManager.RegisterRoutedEvent("VClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent BClickEvent =
            EventManager.RegisterRoutedEvent("BClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent NClickEvent =
            EventManager.RegisterRoutedEvent("NClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public static RoutedEvent MClickEvent =
            EventManager.RegisterRoutedEvent("MClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(Teclado));

        public event RoutedEventHandler QClick {
            add { AddHandler(QClickEvent, value); }
            remove { RemoveHandler(QClickEvent, value); }
        }

        public event RoutedEventHandler WClick
        {
            add { AddHandler(WClickEvent, value); }
            remove { RemoveHandler(WClickEvent, value); }
        }

        public event RoutedEventHandler EClick
        {
            add { AddHandler(EClickEvent, value); }
            remove { RemoveHandler(EClickEvent, value); }
        }

        public event RoutedEventHandler RClick
        {
            add { AddHandler(RClickEvent, value); }
            remove { RemoveHandler(RClickEvent, value); }
        }

        public event RoutedEventHandler TClick
        {
            add { AddHandler(TClickEvent, value); }
            remove { RemoveHandler(TClickEvent, value); }
        }

        public event RoutedEventHandler YClick
        {
            add { AddHandler(YClickEvent, value); }
            remove { RemoveHandler(YClickEvent, value); }
        }

        public event RoutedEventHandler UClick
        {
            add { AddHandler(UClickEvent, value); }
            remove { RemoveHandler(UClickEvent, value); }
        }

        public event RoutedEventHandler IClick
        {
            add { AddHandler(IClickEvent, value); }
            remove { RemoveHandler(IClickEvent, value); }
        }

        public event RoutedEventHandler OClick
        {
            add { AddHandler(OClickEvent, value); }
            remove { RemoveHandler(OClickEvent, value); }
        }

        public event RoutedEventHandler PClick
        {
            add { AddHandler(PClickEvent, value); }
            remove { RemoveHandler(PClickEvent, value); }
        }

        public event RoutedEventHandler AClick
        {
            add { AddHandler(AClickEvent, value); }
            remove { RemoveHandler(AClickEvent, value); }
        }

        public event RoutedEventHandler SClick
        {
            add { AddHandler(SClickEvent, value); }
            remove { RemoveHandler(SClickEvent, value); }
        }

        public event RoutedEventHandler DClick
        {
            add { AddHandler(DClickEvent, value); }
            remove { RemoveHandler(DClickEvent, value); }
        }

        public event RoutedEventHandler FClick
        {
            add { AddHandler(FClickEvent, value); }
            remove { RemoveHandler(FClickEvent, value); }
        }

        public event RoutedEventHandler GClick
        {
            add { AddHandler(GClickEvent, value); }
            remove { RemoveHandler(GClickEvent, value); }
        }

        public event RoutedEventHandler HClick
        {
            add { AddHandler(HClickEvent, value); }
            remove { RemoveHandler(HClickEvent, value); }
        }

        public event RoutedEventHandler JClick
        {
            add { AddHandler(JClickEvent, value); }
            remove { RemoveHandler(JClickEvent, value); }
        }

        public event RoutedEventHandler KClick
        {
            add { AddHandler(KClickEvent, value); }
            remove { RemoveHandler(KClickEvent, value); }
        }

        public event RoutedEventHandler LClick
        {
            add { AddHandler(LClickEvent, value); }
            remove { RemoveHandler(LClickEvent, value); }
        }

        public event RoutedEventHandler ZClick
        {
            add { AddHandler(ZClickEvent, value); }
            remove { RemoveHandler(ZClickEvent, value); }
        }

        public event RoutedEventHandler XClick
        {
            add { AddHandler(XClickEvent, value); }
            remove { RemoveHandler(XClickEvent, value); }
        }

        public event RoutedEventHandler CClick
        {
            add { AddHandler(CClickEvent, value); }
            remove { RemoveHandler(CClickEvent, value); }
        }

        public event RoutedEventHandler VClick
        {
            add { AddHandler(VClickEvent, value); }
            remove { RemoveHandler(VClickEvent, value); }
        }

        public event RoutedEventHandler BClick
        {
            add { AddHandler(BClickEvent, value); }
            remove { RemoveHandler(BClickEvent, value); }
        }

        public event RoutedEventHandler NClick
        {
            add { AddHandler(NClickEvent, value); }
            remove { RemoveHandler(NClickEvent, value); }
        }

        public event RoutedEventHandler MClick
        {
            add { AddHandler(MClickEvent, value); }
            remove { RemoveHandler(MClickEvent, value); }
        }

        public void HandlerComun(object sender, EventArgs e) {
            letraActualOprimida = ((Button)sender).Content.ToString();
            if (sender == botonQ.boton) {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = QClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonW.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = WClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonE.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = EClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonR.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = RClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonT.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = TClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonY.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = YClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonU.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = UClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonI.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = IClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonO.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = OClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonP.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = PClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonA.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = AClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonS.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = SClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonD.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = DClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonF.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = FClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonG.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = GClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonH.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = HClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonJ.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = JClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonK.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = KClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonL.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = LClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonZ.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = ZClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonX.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = XClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonC.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = CClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonV.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = VClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonB.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = BClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonN.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = NClickEvent;
                RaiseEvent(ea);
            }
            else if (sender == botonM.boton)
            {
                RoutedEventArgs ea = new RoutedEventArgs();
                ea.RoutedEvent = MClickEvent;
                RaiseEvent(ea);
            }

        }

        public Teclado()
		{
			this.InitializeComponent();
            botonQ.boton.Click += HandlerComun;
            botonW.boton.Click += HandlerComun;
            botonE.boton.Click += HandlerComun;
            botonR.boton.Click += HandlerComun;
            botonT.boton.Click += HandlerComun;
            botonY.boton.Click += HandlerComun;
            botonU.boton.Click += HandlerComun;
            botonI.boton.Click += HandlerComun;
            botonO.boton.Click += HandlerComun;
            botonP.boton.Click += HandlerComun;
            botonA.boton.Click += HandlerComun;
            botonS.boton.Click += HandlerComun;
            botonD.boton.Click += HandlerComun;
            botonF.boton.Click += HandlerComun;
            botonG.boton.Click += HandlerComun;
            botonH.boton.Click += HandlerComun;
            botonJ.boton.Click += HandlerComun;
            botonK.boton.Click += HandlerComun;
            botonL.boton.Click += HandlerComun;
            botonZ.boton.Click += HandlerComun;
            botonX.boton.Click += HandlerComun;
            botonC.boton.Click += HandlerComun;
            botonV.boton.Click += HandlerComun;
            botonB.boton.Click += HandlerComun;
            botonN.boton.Click += HandlerComun;
            botonM.boton.Click += HandlerComun;
		}

        public String letraActualOprimida = "";
	}
}