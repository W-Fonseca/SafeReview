   M S B A M L   `   `   `  ����E  ASafeReview, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Code_InspectorCode_Inspector  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      !    Code_Inspector.Page_Grafico   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Code_Inspector     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      6sys&clr-namespace:System;assembly=mscorlib     5        N� Title$  Page_Grafico��5      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $��2* �6   6,   �� 5      $��2* �6   6,   �� 5      $��2* �6   6,   �� 5      $��1* �6   6,   �� 5      $��2* �6   6,   �� 5      $��2* �6   6,   �� 5      $��1* �6   6,   �� 5       $��2* �6   6,   �� 5!      $��2* �6   6,   �� 5"      $��3* �6   6,   �� 5#      $��2* �6   6,   �� 5$      $��2* �6   6,   �� 5%      $��1* �6   6,   �� 5&      $��2* �6   6,   �� 5'      $��2* �6   6,   �� 5(      $��1* �6   6,   �� 5)      $��2* �6   6,   �� 5*      $��2* �6   6,   �� 5+      $��2* �6   6,   .+�5/   
   �� $��0��6   $��1��6"   $��1��63   $��6��6C   $��Center=�6W   .+�50      ��  J� Opacity$ .4Q�6   $��13(�6%   
�������$�� ��6F   �� 51       �� Orientation$ 
Horizontal=�6   .+�52      �� 
�������$ .4Q�6/   $��13(�6<      Page_Grafico_text1#���   6J   �� 53      
���  ��$��13(�6-   $��Bottom=�6;   $
��8, 6q�6V   6f   54      55      �� 58   
   $��1��6   $��1��6"   $��12��63   $��6��6D   $��Center=�6X   .+�59      �� $ .4Q�6   $��13(�6%   
�������  Page_Grafico_text2#���  6F   �� 5:      $ 
Horizontal=�6   .+�5;      �� 
�������$��40(�6/    " criar_cabecalho_Processo_title#���  6=   �� 5<      
���  ��$��18(�6-   $��Bottom=�6;   $
��8, 6q�6V   6f   5=      5>      �� 5@   
   $��4��6   $��1��6"   $��12��63   $��6��6D   $��Center=�6X   .+�5A      �� $ .4Q�6   $��13(�6%   
�������#���   6F   �� 5B      $ 
Horizontal=�6   .+�5C      �� 
�������$��40(�6/    ! criar_cabecalho_Objetos_title#���  6=   �� 5D      
��� ���$��18(�60   $��Bottom=�6>   $
��8, 6q�6Y   6i   5E      5F        LiveCharts.Wpf.PieChart  5H   
   -   5          Name$ Grafico2��5H      $��Stretch=�6)   $��Stretch=�6E   $��2��6c   $��2��6p   $��12��6�   $��6��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   &   LiveCharts.Wpf.Charts.Base.Chart   Series 6�   �� *SeriesCollection2+6�     5I   
   -   5        $ Grafico��5I      $��Stretch=�6(   $��Stretch=�6D   $��5��6b   $��2��6o   $��12��6�   $��6��6�   $ 0.5,0.5&�6�    6�   �� *SeriesCollection+6�   #  LiveCharts.Wpf.CartesianChart  5L   
   $��1��6N   $��6��6[   $��0��6l   $��11��6|    6   �� *SeriesCollection_BasicColumn+   AxisX 5N        LiveCharts.Wpf.Axis  	   
Foreground
	 �����
   Labels
 6   �� *BasicColumnLabels+5O         AxisY 5S          Page_Grafico_text3   Title# �  6   6J   5U      5X      5Y      