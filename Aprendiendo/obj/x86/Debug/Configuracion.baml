   M S B A M L   `   `   `  ����  Aprendiendo    Aprendiendo.Configuracion   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5      >d2http://schemas.microsoft.com/expression/blend/2008    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    6?   -   5          �Name$  Window��5       � Title$ Configuracion��5      $	��400��5      $	��190��6    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�61   .��5
      � -   5         �Name$ 
LayoutRoot��5
      $	��Top=�6   .+�5      �� $��0q�6   .@�5      �� -   5         ��Name$ tabConexion��5      $��	Conexión��6"   .��5      � $	��Top=�6    � ColumnDefinitions 5      �� 5      $
��0.5* �6   �� 5      $
��0.5* �6    � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5      �� $��Right=�6   $��0,3,5,3q�6-   $��Utilizar este host como:��6>   $
��Wrap=�6^   � 5      $��5,0,0,0q�6   $��1��6    5      �� 5   	   $
��0.5* �6   �� 5   	   $
��0.5* �6   .+�5      	� $	��0,3q�6   $��Servidor��6!   $
��Left=�64    	� 	GroupName$ grupoTipoHost��6O   	 d� 	IsChecked	 6i   �� *
esServidor+
 �� Mode$
 TwoWay=�	� 5      $	��0,3q�6   $��Cliente��6!   $
��Left=�63   $��54��6N   $��1��6Y   $ grupoTipoHost��6f   	 6�   �� *	esCliente+$
 TwoWay=�5       �� 5!      $��Right=�6   $��0,3,5,3q�6-   $��IP del Servidor:��6>   $
��Wrap=�6V   $��1��6j   �� 5"      -   5         ��Name$ txtIP��5"      $��5,3,10,3q�6   $��1��60   $��1��6=   $	��Top=�6M    �� 	MaxLength$ 16��6e    �� MaxLines$ 1��6t    �� TextWrapping$
 Wrap=�6�   ��6�   �� *
ipServidor+$
 TwoWay=��� 5#      $��Right=�6   $��0,3,5,3q�6-   $��Puerto del Servidor:��6>   $
��Wrap=�6Z   $��2��6n   �� 5$      -   5        $ 	txtPuerto��5$      $��5,3,10,3q�6"   $��2��64   $��1��6A   $	��Top=�6Q   $ 11��6i   $ 1��6x   $
 Wrap=�6�   ��6�   �� *puertoServidor+$
 TwoWay=�� 5%      $��0q�6   $��2��6   $��3��6+    5&      �� 5'   	   $��* �6   �� 5(   	   $
��Auto �6   �� 5)   	   $
��Auto �6   .+�5+      �� -   5         ��Name$ btnConectar��5+      $��Right=�6$   $��5,3,0,3q�6@   $��Bottom=�6Q   $��Conectar��6l   $��1��6   $��13.333(�6�   �� 5,      -   5        $ btnCancelar��5,      $��Right=�6$   $��3,3,10,3q�6@   $��Bottom=�6R   $��Cancelar��6m   $��2��6�   $��13.333(�6�   5-      5.      5/      50      51      52      