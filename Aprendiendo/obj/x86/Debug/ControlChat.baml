   M S B A M L   `   `   `  ����T  PAvalonDock, Version=1.2.2083.0, Culture=neutral, PublicKeyToken=85a1e0ada7ec13e4;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5      L HLuminaryFramework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP:clr-namespace:LuminaryFramework;assembly=LuminaryFrameworkLuminaryFramework 5      F BAprendiendo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AprendiendoAprendiendo 5	      M+clr-namespace:Aprendiendo.controles.tecladoAprendiendo.controles.teclado 5
      E'clr-namespace:Aprendiendo.luminary.chatAprendiendo.luminary.chat 5         Aprendiendo.ControlChat   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5      >d2http://schemas.microsoft.com/expression/blend/2008    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      A
AvalonDock,clr-namespace:AvalonDock;assembly=AvalonDock    5      VLuminaryFramework:clr-namespace:LuminaryFramework;assembly=LuminaryFramework    5      )localclr-namespace:Aprendiendo    5	      SAprendiendo_controles_teclado+clr-namespace:Aprendiendo.controles.teclado    5
      BAprendiendo_chat'clr-namespace:Aprendiendo.luminary.chat    5      -   5          >�Name$  UserControl��5       � 	Resources 5      H  BAprendiendo.luminary.chat.AdministradorEstaConectadoModalConverter ,  (administradorEstaConectadoModalConverterM  GAprendiendo.luminary.chat.AdministradorEstaConectadoEfectoBlurConverter 1 -administradorEstaConectadoEfectoBlurConverter  TabItemFocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  TabControlNormalBorderBrush �� Color  ButtonNormalBackground �� EndPoint �� 
StartPoint	 � Color
 � Offset  TabItemHotBackground  TabItemSelectedBackground  TabItemHotBorderBrush  TabItemDisabledBackground 	 TabItemDisabledBorderBrush 
 EstiloTabControlesEntrada �� 
TargetType �� 
TargetType ��Name �� Padding ��Name �� RelativeSource �� AncestorType �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value  EstiloTabControlControles-  'System.Windows.Input.KeyboardNavigation   TabNavigation � ColumnDefinitions ��Name � RowDefinitions ��Name ��Name K� IsItemsHost  K� ZIndex!   TabIndex"   DirectionalNavigation��%�  &	        &	      &	 &     &	 �     &	 �     &	 �    &	 �    &	     &	 &    &		 G    &	
 j    7  7  7  7  7  7 	 &	 ,    7    5   
   6D     5      6C   �� 5      .�5      ��  � �� 5      �� 5      .R�5      �� 
���   �$	 1 2R�6!   $��1��67   $��3,3,3,1q�6K    . 6\   5      5      5      �� 5      $ #8C8E94��68   �� 5      $	 0,1&�67   $	 0,0&�6F   .��5      � $	 #F3F3F3��6   $
 0Q�6"   � 5      $	 #EBEBEB��6   $	
 0.5Q�6"   � 5      $	 #DDDDDD��6   $	
 0.5Q�6"   � 5      $	 #CDCDCD��6   $
 1Q�6"   5       �� 5!      $	 0,1&�65   $	 0,0&�6D   .��5"      � $	 #EAF6FD��6   $

 0.15Q�6"   � 5#      $	 #D9F0FC��6   $
 .5Q�6"   � 5$      $	 #BEE6FD��6   $
 .5Q�6"   � 5%      $	 #A7D9F5��6   $
 1Q�6"   5&      �� 5'      $ #F9F9F9��66   �� 5(      $ #3C7FB1��62   �� 5)      $ #F4F4F4��66   �� 5*      $ 	#FFC9C7BA��67   �� 5+      " ��6,   .�5,      ��  �@�FocusVisualStyle8   6(   �� 5-       � ��
 �   �6"   �� 5.       � ��$ 6,1,6,1q�6   �� 5/       � ��8  6#   �� 50       � ��8  6"   �� 51       � ��$ Stretch=�62   �� 52       � ��$ Stretch=�60   �� 53       � �� 54      �� 55      " ��6   .R�56      �  . .+�57   	   �� $ Bd��6   #��z��6   $��1,1,1,0q�6H   # z��6b   ��58   
   �� 59      $	 0,1&�6   $	 0,0&�6.   .��5:      � $	 	#FF3B3B3B��6   $
 0Q�6+   � 5;      $	 	#FF636363��6   $
 1Q�6+   5<      ._�5>   
   �� 
�������$��Calibri)�6#   $��13.333(�68   .��5?      �� $ Content��6   # z 6'  $��Header��6c  ��. ��6-   �� *HorizontalContentAlignment+ �� " ����6�   �� *VerticalContentAlignment+ �� " ��6z  5@      5A   
   5B   	    5C      P� 5D   	    �@J�IsMouseOver . . �5E   
   �� $ Bd��6'    � �� 5F      �� 5G      $	 0,1&�6    $	 0,0&�6/   .��5H      � $	 	#FF3B3B3B��6   $
 0Q�6,   � 5I      $	 	#FF044070��6   $
 1Q�6,   5J      5L      5M   
   P� 5N   	    �@��
IsSelected . . �5O   
   ��  �@K�ZIndex$ 1��6)   �� 5P   
   $ Bd��6'    � �� 5Q      �� 5R      $ 0.5,1&�6    $ 0.5,0&�61   .��5S      � $	 	#FFC2C2C2��6   $
 0Q�6,   � 5T      $	 	#FF888888��6   $
 1Q�6,   5U      5W      �� 5X   
   $ Bd��6,    � ��$ 0q�6<   5Y   
   ]� 5Z   	    5[   
   �� 5\       �@��
IsSelected .  6+   �� 5]       �@J�IsMouseOver . 6,   ./�5_   
   �� $ Bd��6(   8   � ��68   5`   
   P� 5a   	    �@��TabStripPlacement$ Bottom=�6.   . �5b   
   �� $ Bd��6,    � ��$ 1,0,1,1q�6<   5c   
   P� 5d   	    �@��TabStripPlacement$
 Left=�6.   . �5e   
   �� $ Bd��6,    � ��$ 1,1,0,1q�6<   5f   
   P� 5g   	    �@��TabStripPlacement$ Right=�6.   . �5h   
   �� $ Bd��6,    � ��$ 0,1,1,1q�6<   5i   
   ]� 5j   	    5k   
   �� 5l       �@��
IsSelected . 6+   �� 5m       �@��TabStripPlacement$	 Top=�62   ./�5o   
   ��  � ��$ -2,-2,-2,-1q�6#   �� 5p   
   $ Content��6#    � ��$ 0,0,0,1q�68   5q   
   ]� 5r   	    5s   
   �� 5t       �@��
IsSelected . 6+   �� 5u       �@��TabStripPlacement$ Bottom=�62   ./�5w   
   ��  � ��$ -2,-1,-2,-2q�6#   �� 5x   
   $ Content��6#    � ��$ 0,1,0,0q�68   5y   
   ]� 5z   	    5{   
   �� 5|       �@��
IsSelected . 6+   �� 5}       �@��TabStripPlacement$
 Left=�62   ./�5   
   ��  � ��$ -2,-2,-1,-2q�6#   �� 5�   
   $ Content��6#    � ��$ 0,0,1,0q�68   5�   
   ]� 5�   	    5�   
   �� 5�       �@��
IsSelected . 6+   �� 5�       �@��TabStripPlacement$ Right=�62   ./�5�   
   ��  � ��$ -1,-2,-2,-2q�6#   �� 5�   
   $ Content��6#    � ��$ 1,0,0,0q�68   5�   
   P� 5�   	    � {� .  . �5�   
   �� $ Bd��6'   8   � ��67   �� 5�   
   $ Bd��6(   8   � ��68   �� 5�   
   # � ��6'    � ��5�   
   5�      5�      5�      �� 5�      " ��6,   .�5�      ��  � ��# � ��6"   �� 5�       � ��$ 4,4,4,4q�6   �� 5�       � ��$ 1q�6'   �� 5�       � ��8   6#   �� 5�       � �� �#F9F9F96"   �� 5�       � ��$ Center=�62   �� 5�       � ��$ Center=�60   �� 5�       � �� 5�      �� 5�      " ��6   .R�5�      � }�.  . $ Local=�6<    5�   	   �� 5�   
   $ ColumnDefinition0��6   �� 5�   
   $ ColumnDefinition1��6   $��0 �66    5�   	   �� 5�   
   $ RowDefinition0��6   $
��Auto �60   �� 5�   
   $ RowDefinition1��6   $��* �60   .+�5�   	   �� $ HeaderPanel��6   $��2,2,2,0q�6'    . $  1��6K   $��0��6\   $��0��6l   $! 1��6y   �� 5�   	   $ ContentPanel��6   #��z��6&   $��0��6Z   $��1��6j   $" 	Contained=�6w   $! 2��6�   $ Local=�6�   ��5�   
   �� 5�      $ 0.5,1&�6   $ 0.5,0&�60   .��5�      � $	 	#FF888888��6   $
 0Q�6+   � 5�      $	 	#00888888��6   $
 1Q�6+   5�      ��5�   
   �� 5�      $ 0.5,1&�6   $ 0.5,0&�60   .��5�      � $	 	#FF888888��6   $
 0Q�6+   � 5�      $	 	#00888888��6   $
 1Q�6+   5�      ._�5�   
   �� $ PART_SelectedContentHost��6   #��z��6=   # z 6`   $��SelectedContent��6�   5�   
   5�   	    5�      P� 5�   	    �@��TabStripPlacement$ Bottom=�6.   . �5�   
   �� $ HeaderPanel��6%    � ��$ 1��6>   �� 5�   
   $ ContentPanel��6%    � ��$ 0��6?   �� 5�   
   $ RowDefinition0��6#    � ��$ * �6?   �� 5�   
   $ RowDefinition1��6#    � ��$
 Auto �6?   �� 5�   
   $ HeaderPanel��6#    � ��$ 2,0,2,2q�6<   5�   
   P� 5�   	    �@��TabStripPlacement$
 Left=�6.   . �5�   
   �� $ HeaderPanel��6%    � ��$ 0��6>   �� 5�   
   $ ContentPanel��6%    � ��$ 0��6?   �� 5�   
   $ HeaderPanel��6(    � ��$ 0��6A   �� 5�   
   $ ContentPanel��6(    � ��$ 1��6B   �� 5�   
   $ ColumnDefinition0��6"    � ��$
 Auto �6A   �� 5�   
   $ ColumnDefinition1��6"    � ��$ * �6A   �� 5�   
   $ RowDefinition0��6#    � ��$ * �6?   �� 5�   
   $ RowDefinition1��6#    � ��$ 0 �6?   �� 5�   
   $ HeaderPanel��6#    � ��$ 2,2,0,2q�6<   5�   
   P� 5�   	    �@��TabStripPlacement$ Right=�6.   . �5�   
   �� $ HeaderPanel��6%    � ��$ 0��6>   �� 5�   
   $ ContentPanel��6%    � ��$ 0��6?   �� 5�   
   $ HeaderPanel��6(    � ��$ 1��6A   �� 5�   
   $ ContentPanel��6(    � ��$ 0��6B   �� 5�   
   $ ColumnDefinition0��6"    � ��$ * �6A   �� 5�   
   $ ColumnDefinition1��6"    � ��$
 Auto �6A   �� 5�   
   $ RowDefinition0��6#    � ��$ * �6?   �� 5�   
   $ RowDefinition1��6#    � ��$ 0 �6?   �� 5�   
   $ HeaderPanel��6#    � ��$ 0,2,2,2q�6<   5�   
   P� 5�   	    � {� .  . �5�   
   �� # � ��6'    � ��5�   
   5�      5�      5�      5�      .��5�      � -   5        # �Name$# 
LayoutRoot��5�      $ J� Effect$ 5�      -  'System.Windows.Media.Effects.BlurEffect  5�      -   5        efectoEstaConectado��%   Radius% 5�   -   �� & �� Path$& estaConectado�' �� 	Converter#' [  5�      �� 5�      $
��0.5* �6   �� 5�      $
��0.5* �6    5�      �� 5�      $��* �6   �� 5�      $��150px �6   .+�5�      � -   5        $# grillaControlesEntrada��5�   	   $��0q�6)   $��2��64   $��1��6H   .+�5�      �� $��0q�6   #���  6   .@�5�      �� $��Teclado��6   #��� 
 6   .��5�      � .+�5�      +  %Aprendiendo.controles.teclado.Teclado  -   5        (  Name$( teclado��5�   9   +  %Aprendiendo.controles.teclado.Teclado)   QClick$) btnTeclado_Click��5�      *   WClick$* btnTeclado_Click��6"   +   EClick$+ btnTeclado_Click��6<   ,   RClick$, btnTeclado_Click��6V   -   TClick$- btnTeclado_Click��5�      .   YClick$. btnTeclado_Click��6"   /   UClick$/ btnTeclado_Click��6<   0   IClick$0 btnTeclado_Click��6V   1   OClick$1 btnTeclado_Click��5�      2   PClick$2 btnTeclado_Click��6"   3   AClick$3 btnTeclado_Click��6<   4   SClick$4 btnTeclado_Click��6V   5   DClick$5 btnTeclado_Click��5�      6   FClick$6 btnTeclado_Click��6"   7   GClick$7 btnTeclado_Click��6<   8   HClick$8 btnTeclado_Click��6V   9   JClick$9 btnTeclado_Click��5�      :   KClick$: btnTeclado_Click��6"   ;   LClick$; btnTeclado_Click��6<   <   ZClick$< btnTeclado_Click��6V   =   XClick$= btnTeclado_Click��5�      >   CClick$> btnTeclado_Click��6"   ?   VClick$? btnTeclado_Click��6<   @   BClick$@ btnTeclado_Click��6V   A   NClick$A btnTeclado_Click��5�      B   MClick$B btnTeclado_Click��6"   $��0q�5�   .   $��Center=�5�   <   $��Center=�6Y   5�      5�      �� 5�      $��Texto��6   #��� 
 6   .��5�      �  5�      �� 5�   	   $��* �6   �� 5�   	   $
��60px �6   .+�5      �� -   5        C ��Name$C 
txtMensaje��5      $��8,8,2.883,8q�6$   D �� TextWrapping$
D Wrap=�69   ���	#FF1C1C1C
�������6d   �� 5     -   5        E ��Name$E 	btnEnviar��5     $��1.117,8,8,8q�6"   $��Enviar��67   $��1��6H   6X   5     5     �� 5     $��Reconocimiento de texto��6   #��� 
 6/   .��5     � .+�5     �� $��8q�6   $
D Wrap=�6   ���	#FF1C1C1C
�������6F   5     5     5	     5
     � 5     -   5        $# grillaYo��5  	   $��0q�6    5     �� 5  	   $
��25px �6   �� 5  	   $��* �6   �� 5  	   $	��150��6   $
��Auto �6'   .+�5        LuminaryFramework.Luminary  -	   5        F  Name$F modelo3D��5      $��0,2,5,-2q�62   $��1��6D   R NArcane.Xna.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"  Arcane.Xna.Presentation.GameG   WPFHost.G 5     � -
   5        $# yoConectadoModal��5     ���	#7F000000$��0q�6<   y�6G   �� $& estaConectado�#' [  .+�5     �� $��Center=�6   $��Center=�6.   $��16(�6I   
�������Desconectado6x   5     5     �� 5     ���	#FF292929$��0,0,5,0q�6$   $��0,0,0,1q�65   H �� CornerRadius$H 5,5,0,0��6O   $ 0q�6f   ��5     �� 5     $ 0.5,1&�6   $ 0.5,0&�6,   .��5     � $	 	#FFC2C2C2��6   $
 0Q�6'   � 5     $	 	#FF888888��6   $
 1Q�6'   5     5     �� 5     $
��Left=�6   $��10,0,0,0q�6&   $
��Auto��68   $��Yo��6E   $��Calibri)�6R   $��14(�6g   I J� RenderTransformOrigin$I 0.253,0.429&�6u   $��Normal"�6�   ���	#FFFFFFFF$��Center=�6�   $��0q�6�   9� 5     -   5        J 9�Name$J expanderControl3D��5     $��0,0,5,0q�6)   $��Controlar vista��6:   $��2��6S   $	��150��6`     EstiloExpander#���  6p   .��5      � .+�5!     	  Aprendiendo.Controles3D	  -   5        K 	 Name$K controles3D��5!  N   $��0q�6   $
��Auto��6$   $��Stretch=�62   $��0q�6c   ���	#FF0000006w   5"     5#     5$     � 5%     -   5        $# grillaElOtro��5%  	   $��0q�6   $��1��6*    5&     �� 5'     $
��25px �6   �� 5(     $��* �6   �� 5)     $	��150��6   $
��Auto �6$   .+�5+       -   5        $F 	modelo3D2��5+      $��5,2,0,-2q�63   $��1��6E   .G 5,     � -   5        $# elOtroConectadoModal��5,     ���	#7F000000$��0q�6@   y�6K   �� $& estaConectado�#' [  .+�5-     �� $��Center=�6   $��Center=�6.   $��16(�6I   
�������Desconectado6x   5.     5/     �� 50     ���	#FF292929$��5,0,0,0q�6$   $��0,0,0,1q�65   $H 5,5,0,0��6O   $ 0q�6f   ��51     �� 52     $ 0.5,1&�6   $ 0.5,0&�6,   .��53     � $	 	#FFC2C2C2��6   $
 0Q�6'   � 54     $	 	#FF888888��6   $
 1Q�6'   55     57     �� 58     $
��Left=�6   $��15,0,0,0q�6&   $
��Auto��68   $��El otro��6E   $��Calibri)�6W   $��14(�6l   $I 0.253,0.429&�6z   $��Normal"�6�   ���	#FFFFFFFF$��Center=�6�   $��0q�6�   9� 59     -   5        $J expanderControl3D1��59     $��5,0,0,0q�6*   $��Controlar vista��6;   $��2��6T   $	��150��6a   #���  6q   .��5:     � .+�5;     	  -   5        $K controles3D1��5;  N   $��0q�6   $
��Auto��6$   $��Stretch=�62   $��0q�6d   ���	#FF0000006x   5<     5=     5>     � 5?     -   5        $# modal��5?  	   $��0q�6   $��2��6#   $��2��67   ���	#7F000000y�6_   �� $& estaConectado�#' [  5@     5A     