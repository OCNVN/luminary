   M S B A M L   `   `   `  ����F  BAprendiendo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Aprendiendo.luminaryAprendiendo.luminary  5   	   M+clr-namespace:Aprendiendo.controles.tecladoAprendiendo.controles.teclado  5   	   $    Aprendiendo.ControlVocabulario   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5      AAprendiendo_luminary"clr-namespace:Aprendiendo.luminary    5   	   9ACT+clr-namespace:Aprendiendo.controles.teclado    5   	   >d2http://schemas.microsoft.com/expression/blend/2008    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    6Y   $
��Auto��5      $
��Auto��6   ��5      Z�   � 	Resources  5	      .   (Aprendiendo.luminary.JuegoImageConverter   imageConverter��%   &	          5
      6-   5      .��5      � $
��Auto��6    � RowDefinitions 5      �� 5      $
��25px �6   �� 5      $��* �6   �� 5      $��130px �6   .+�5      �� $��0,0,0,-1q�6   ���	#FFCCCCCC��5       �� 5!   	    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6.   .��5"   
   �  � Color$ 	#FFFFFFFF��6    � Offset$ 0Q�6)   � 5#   
   $ 	#FFCECECE��6   $ 1Q�6)   � 5$   
   $ 	#FFF1F1F1��6   $ 0.518Q�6)   5%   
   5'      �� 55      $
��Left=�6   $��10,0,0,0q�6(   $
��Auto��6:   $��Introduzca el texto��6G   $��Calibri)�6e   $��14(�6z    J� RenderTransformOrigin$ 0.253,0.429&�6�   $��Normal"�6�   +   %Aprendiendo.controles.teclado.Teclado  56      -   5          Name$ teclado��56   +   +   %Aprendiendo.controles.teclado.Teclado   QClick$ btnTeclado_Click��57      	   WClick$	 btnTeclado_Click��6!   
   EClick$
 btnTeclado_Click��6;      RClick$ btnTeclado_Click��6U      TClick$ btnTeclado_Click��58         YClick$ btnTeclado_Click��6!      UClick$ btnTeclado_Click��6;      IClick$ btnTeclado_Click��6U      OClick$ btnTeclado_Click��59         PClick$ btnTeclado_Click��6!      AClick$ btnTeclado_Click��6;      SClick$ btnTeclado_Click��6U      DClick$ btnTeclado_Click��5:         FClick$ btnTeclado_Click��6!      GClick$ btnTeclado_Click��6;      HClick$ btnTeclado_Click��6U      JClick$ btnTeclado_Click��5;         KClick$ btnTeclado_Click��6!      LClick$ btnTeclado_Click��6;      ZClick$ btnTeclado_Click��6U      XClick$ btnTeclado_Click��5<         CClick$ btnTeclado_Click��6!      VClick$ btnTeclado_Click��6;      BClick$ btnTeclado_Click��6U       NClick$  btnTeclado_Click��5=      !   MClick$! btnTeclado_Click��6!   $��31,8,0,22.059q�56      $
��Left=�5=   ;   $	��365��6V   $��2��6b   �� 5>      $��31,0,0,-193q�6   $��87��6#   $��Bottom=�6/   $
��Left=�6J   $	��353��6e   $��2��6q   " J� OpacityMask" 5?      �� 5@   	   $	 0,0&�6   $
 0,03&�6.   .��5A   
   � $ .0Q�6   $ Transparent��6#   � 5B   
   $ .9Q�6   $ White��6#   5C   
   z�5E      V� 5F   	   .~�5G   
   �� # �� ScaleX$# 1Q�6   $ �� ScaleY$$ -1Q�6$   �� 5H   
   % �� AngleX$% 0Q�6   & �� AngleY$& 0Q�6#   �� 5I   
   ' �� Angle$' 0Q�6   T� 5J   
   ( T� X$( 0Q�6   ) T� Y$) -39.277Q�6#   5K   
   ��5M      !� 5N   	   * !� Visual* 6   �� + �� ElementName$+ teclado��5P      �� 5Q      -   5        , ��Name$, 
imageSenas��5Q   !   $��
0,22,55,54q�6   $��2��6�   $��Right=�6�   $��53.872��6�   ��65   �� - �� Path$- imageRef�. �� 	Converter#. [  6�   �� 5R      -   5        / ��Name$/ txtIngresar��5R   $   0 �� AcceptsReturn0 . 1 �� TextWrapping$
1 Wrap=�69   $��12(�6M   ���	#FF0000002 J� 	AllowDrop2 .  $��0,0,0,0q�6�   ���	#FFCCCCCC$��1��6�   ���	#FFFFFFFF$��Verdana)�6�   ��6r   �� $- 
textoFrase�3 �� Mode$3 TwoWay=�6�   �� 5T      -   5        4 ��Name$4 btnTraducir��5T   (   $��369.5,45.059,0,0q�6   $��Traducir��6=   $��2��6j   $ -0.418,-0.543&�6w   $
��Left=�6�   $	��Top=�6�   $��62.941��6�   $��65.047��6  5V      5W      