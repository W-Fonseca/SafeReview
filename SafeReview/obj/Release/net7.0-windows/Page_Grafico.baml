   M S B A M L   `   `   `  ���� E  ASafeReview, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Code_InspectorCode_Inspector  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem !    Code_Inspector.Page_Grafico   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:Code_Inspector     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     6sys&clr-namespace:System;assembly=mscorlib       N� Title$  Page_Grafico��.���  � RowDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* � � ColumnDefinitions �� $��2* ��� $��2* ��� $��2* ��� $��1* ��� $��2* ��� $��2* ��� $��1* ��� $��2* ��� $��2* ��� $��3* ��� $��2* ��� $��2* ��� $��1* ��� $��2* ��� $��2* ��� $��1* ��� $��2* ��� $��2* ��� $��2* �.+��� $��0��$��1��$��1��$��6��$��Center=�.+���  J� Opacity$ .4Q�$��13(�
�������$�� ����  �� Orientation$ 
Horizontal=�.+��� 
�������$ .4Q�$��13(�   Page_Grafico_text1#���   �� 
���  ��$��13(�$��Bottom=�$
��8, 6q��� $��1��$��1��$��12��$��6��$��Center=�.+��� $ .4Q�$��13(�
�������  Page_Grafico_text2#���  �� $ 
Horizontal=�.+��� 
�������$��40(� " criar_cabecalho_Processo_title#���  �� 
���  ��$��18(�$��Bottom=�$
��8, 6q��� $��4��$��1��$��12��$��6��$��Center=�.+��� $ .4Q�$��13(�
�������#���   �� $ 
Horizontal=�.+��� 
�������$��40(� ! criar_cabecalho_Objetos_title#���  �� 
��� ���$��18(�$��Bottom=�$
��8, 6q�  LiveCharts.Wpf.PieChart  -     Name$ Grafico2��$��Stretch=�$��Stretch=�$��2��$��2��$��12��$��6�� J� RenderTransformOrigin$ 0.5,0.5&�&   LiveCharts.Wpf.Charts.Base.Chart   Series �� *SeriesCollection2+  -   $ Grafico��$��Stretch=�$��Stretch=�$��5��$��2��$��12��$��6��$ 0.5,0.5&� �� *SeriesCollection+#  LiveCharts.Wpf.CartesianChart  $��1��$��6��$��0��$��11�� �� *SeriesCollection_BasicColumn+   AxisX   LiveCharts.Wpf.Axis  	   
Foreground
	 �����
   Labels
 �� *BasicColumnLabels+   AxisY     Page_Grafico_text3   Title# �  