   M S B A M L   `   `   `  ����E  ASafeReview, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SafeReview
SafeReview  5   	       SafeReview.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SafeReview     5   	   -   5          � Title$  CogniShield��5   	   $	��800��5	   	   $	��900��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � Icon$  /Assets/Cognition_Logo.png��5   	   ��5   	   Z� ��5   	   Z� .��5      � .+�5   
   �� -   5         ��Name$ Borda��5      ���	#FF1C2D40$��5,6,5,6q�5       �� CornerRadius$ 0,0,0,0��5      $
}�True��6(   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      � 	 � Color$	 White��6#   
 � Offset$
 0.133Q�61   � 5      $	 	#FF6AC399��6#   $

 0.69Q�65   � 5      $	 	#FF5ACBE3��6#   $
 0.407Q�65   5      5      � 5"   
   $��Right=�6   $	��Top=�6+   $��	0,15,75,0q�6C   .+�5#      �� -   5        $��30��5#      $��30��6#   $��Center=�6/   $��Center=�6L   
������� J� Opacity$ 0Q�6�   6�   �� 5$      -   5        $
�� −��5$      $��Center=�6"   $��Center=�6?   $��15��6Z   $��15��6e   
�������6�   5%      � 5'   
   $��Right=�6   $	��Top=�6+   $��	0,15,45,0q�6C   .+�5(      �� -   5        $��30��5(      $��30��6#   $��Center=�6/   $��Center=�6L   
�������$ 0Q�6�   6�   �� 5)      -   5        $
�� □��5)      $��Stretch=�6"   $��Center=�6@   $��15��6[   $��15��6f   
�������6�   5*      � 5-   
   -   5        $��Right=�5-      $	��Top=�6+   $��	0,15,15,0q�6C   .+�5.      �� -   5        $��30��5.      $��30��6#   $��Center=�6/   $��Center=�6L   
�������$ 0Q�6�   �� 5/      -	   5        $�� x��5/      $��15��6#   $��15��6.   
�������$��Center=�6M   $��Center=�6j   6�   50      � 54   
    J� RenderTransformOrigin$ 0.5,0.5&�6   z�55      V� 56      .~�57      �� �� 58      �� 59      T� 5:       T� X$ 5Q�6)   5;       � ColumnDefinitions 5>      �� 5?      $��0 �6#   �� 5@      $
��200* �6#   �� 5A      $
��320* �6#   �� 5B      $��1* �6#   �� 5C      $	��20* �6#   �� 5D      $��2000* �6#   �� 5E      $	��20* �6#    � RowDefinitions 5J      �� 5L      $
��0.6* �6    �� 5M      $
��0.7* �6    �� 5N      $
��0.7* �6    �� 5O      $
��0.7* �6    �� 5P      $
��0.7* �6    �� 5Q      $
��0.7* �6    �� 5R      $
��0.7* �6    �� 5S      $
��0.7* �6    �� 5T      $
��0.5* �6    .+�5[      �� 
���   �$	 0.6Q�6%    J� SnapsToDevicePixels$
 True��63   $��1��6N   $��3��6^   $��0��6r   $��0,6,0,0q�6   �� 5\      -
   5        
���   �$	 0.6Q�5\   %   $
 True��63   $��1��6N   $��3��6^   $��1��6r   6�   �� 5]      -   5        
���   �$	 0.6Q�5]   %   $
 True��63   $��1��6N   $��3��6^   $��2��6r   6�   �� 5^      -   5        
���   �$	 0.6Q�5^   %   $
 True��63   $��1��6N   $��3��6^   $��3��6r   6�   �� 5_      -   5        
���   �$	 0.6Q�5_   %   $
 True��63   $��1��6N   $��3��6^   $��4��6r   6�   �� 5`      -   5        
���   �$	 0.6Q�5`   %   $
 True��63   $��1��6N   $��3��6^   $��5��6r   6�   �� 5a      -   5        
���   �$	 0.6Q�5a   %   $
 True��63   $��1��6N   $��3��6^   $��6��6r   6�   �� 5b      -   5        
���   �$	 0.6Q�5b   %   $
 True��63   $��1��6N   $��3��6^   $��7��6r   6�   �� 5c      
���   �$	 0.6Q�6%   $
 True��63   $��1��6N   $��3��6^   $��8��6r   $��0,0,0,6q�6   (� 5e      $��5��6   $��0��6&   .��5f      �� $��Center=�6   $��Center=�65   $��1��6Q   $��0��6a   $)��#Assets/Cognition_LOGO_white_RGB.png��6n   $ 0.5,0.5&�6�   $��	0,0,463,0q�6�   z�5g      V� 5h      .~�5i      ��  �� ScaleX$	 0.8Q�6)    �� ScaleY$	 0.8Q�66   �� 5j      �� 5k      T� 5l      5m      5o      5p      (� 5q      $��2��6   $��0��6&   .��5r      �� $��    ogniShield��6   $��20(�61   $��2��6@   
�������$
��Left=�6c   $��Center=�6~   $��-44,12,10,0q�6�   $��
Gilroy ☞)�6�   5s      (� 5t      $��2��6   $��0��6&   .��5u      �� $��Center=�6   $��Center=�65   $)��#Assets/Cognition_LOGO_white_RGB.png��6Q   $ 0.5,0.5&�6~   $��-160,50,400,0q�6�   z�5v      V� 5w      .~�5x      �� $	 0.8Q�6-   $	 0.8Q�6:   �� 5y      �� 5z      T� 5{      5|      5~      5      (� 5�      $��5��6   $��0��6&   .��5�      �� $��	Cognition��6   $��20(�6,   $��2��6;   
�������$
��Left=�6^   $��Center=�6y   $��	-33,3,0,0q�6�   $��
Gilroy ☞)�6�   5�      (� 5�      $��5��6   $��0��6&   .��5�      �� 
�������$��Center=�6'   $��Center=�6D   $��Powered By Symphony��6_   $��5(�6}   $��Gilroy Bold)�6�   $��0��6�   $��2��6�   $��18,23,12,-1.7q�6�   5�      (� 5�      -   5        $��1��5�      $��1��6&   $	 0.6Q�63   .��5�      �� -   5        $��Center=�5�      $��Center=�65   $��1��6Q   $��1��6a   $��/icons8-bug-100.png��6�   $ 0.5,0.5&�6�   $��-21,-21,-21,-21q�6  z�5�      V� 5�      .~�5�      �� $	 0.5Q�6)   $	 0.5Q�66   �� 5�      �� 5�      T� 5�      5�      5�      5�      (� 5�      -   5        $��1��5�      $��2��6&   $	 0.6Q�63   .��5�      �� -   5        $��Center=�5�      $��Center=�65   $��1��6Q   $��2��6a   $'��!Assets/icons8-combo-chart-100.png��6�   $ 0.5,0.5&�6�   $��-21,-21,-21,-21q�6  z�5�      V� 5�      .~�5�      �� $	 0.5Q�6-   $	 0.5Q�6:   �� 5�      �� 5�      T� 5�      5�      5�      5�      (� 5�      -   5        $��1��5�      $��3��6&   $	 0.6Q�63   .��5�      �� -   5        $��Center=�5�      $��Center=�65   $��1��6Q   $��3��6a   $��/icons8-genealogy-100.png��6�   $ 0.5,0.5&�6�   $��-21,-21,-21,-21q�6  z�5�      V� 5�      .~�5�      �� $	 0.5Q�6-   $	 0.5Q�6:   �� 5�      �� 5�      T� 5�      5�      5�      5�      (� 5�      -   5        $��1��5�      $��4��6&   $	 0.6Q�63   .��5�      �� -   5        $��Center=�5�      $��Center=�65   $��1��6Q   $��4��6a   $-��'/Assets/icons8-diário-de-bordo-100.png��6�   $ 0.5,0.5&�6�   $��-21,-21,-21,-21q�6  z�5�      V� 5�      .~�5�      �� $	 0.5Q�6-   $	 0.5Q�6:   �� 5�      �� 5�      T� 5�      5�      5�      5�      (� 5�      -   5        $��1��5�      $��5��6&   $	 0.6Q�63   .��5�      �� -   5        $��Center=�5�      $��Center=�65   $��1��6Q   $��5��6a   $��/icons8-idea-100.png��6�   $ 0.5,0.5&�6�   $��-21,-21,-21,-21q�6  z�5�      V� 5�      .~�5�      �� $	 0.5Q�6-   $	 0.5Q�6:   �� 5�      �� 5�      T� 5�      5�      5�      5�      (� 5�      -   5        $��2��5�      $��1��6&   $	 0.6Q�6�   .��5�      �� -   5           Inspect_Release#���   5�      $��
Gilroy ☞)�6D   $��14(�6Z   $��2��6h   
�������$��Center=�6�   $��Center=�6�    � ToolTip 5�      _� 5�      $��Inspeciona uma release��6"   5�      5�      (� 5�      -   5        $��2��5�      $��2��6&   $	 0.6Q�6�   .��5�      �� -   5          	Dashboard#���  5�      $��
Gilroy ☞)�6>   $��14(�6T   $��2��6b   
�������$��Center=�6�   $��Center=�6�    5�      _� 5�      $%��Gera um grafico sobre a release��6"   5�      5�      (� 5�      -   5        $��2��5�      $��3��6&   $	 0.6Q�6�   .��5�      �� -    5          
Create_ODI#���  5�      $��
Gilroy ☞)�6?   $��14(�6U   
�������$��Center=�6v   $��Center=�6�    5�      _� 5�      $*��$Gera Instrução de Design de Objeto��6"   5�      5�      (� 5�      -!   5        $��2��5�      $��4��6&   $	 0.6Q�6�   .��5�      �� -"   5          	Documents#���  5�      $��
Gilroy ☞)�6>   $��14(�6T   
�������$��Center=�6u   $��Center=�6�    5�      _� 5�      $-��'Documentação sobre melhores práticas��6"   5�      5�      (� 5�      -#   5        $��2��5�      $��5��6&   $	 0.6Q�6�   .��5�      �� -$   5          Feedback_ideas#���  5�      $��
Gilroy ☞)�6D   $��14(�6Z   
�������$��2��6{   $��Center=�6�   $��Center=�6�    5�      _� 5�      $!��Envie seu feedback ou ideia��6"   5�      5�      (� 5�      -%   5        $��2��5�      $��6��6&   $	 0.6Q�6�   .��5�      �� -&   5          Information#���  5�      $��
Gilroy ☞)�6@   $��14(�6V   
�������$��2��6w   $��Center=�6�   $��Center=�6�   6�   5�      (� 5�      -'   5        $��1��5�      $��6��6&   $	 0.6Q�63   .��5�      �� -(   5        $��Center=�5�      $��Center=�65   $��1��6Q   $��6��6a   $��/icons8-info-100.png��6�   $ 0.5,0.5&�6�   $��-21,-21,-21,-21q�6  z�5�      V� 5�      .~�5�      �� $	 0.5Q�6-   $	 0.5Q�6:   �� 5�      �� 5�      T� 5�      5�      5�      5�      (� 5�      -)   5        $��2��5�      $��7��6&   $	 0.6Q�6�   .��5�      �� -*   5          configuracoes#���  5�      $��
Gilroy ☞)�6B   $��14(�6X   
�������$��2��6y   $��Center=�6�   $��Center=�6�   6�   5�      (� 5�      -+   5        $��1��5�      $��7��6&   $	 0.6Q�63   .��5�      �� -,   5        $��Center=�5�      $��Center=�65   $��1��6Q   $��6��6a   $��/icons8-config-100.png��6�   $ 0.5,0.5&�6�   $��-21,-21,-21,-21q�6  z�5�      V� 5�      .~�5�      �� $	 0.5Q�6-   $	 0.5Q�6:   �� 5�      �� 5�      T� 5�      5      5     5      � 5     --   5          �Name$
 Main��5       � NavigationUIVisibility$ Hidden=�6"   $��5��6B   $��1��6R   $��7��6_   $ 0.5,0.5&�6p   z�5     V� 5     .~�5     �� $
 0.95Q�6)   $
 1.05Q�67   �� 5	     �� 5
     T� 5     $ 0Q�6-    T� Y$ 19Q�63   5     5     5     5     5     