   M S B A M L   `   `   `  ����F  BBus_Station, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Bus_Station.ViewBus_Station.View  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       Bus_Station.View.Diagram   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Bus_Station.View     5   	   DWpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � Title$  Графики��5	   	   $	��780��6   $	��800��6&    � 	Resources 5
         show �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Mode �� Value  hide��%�  &	        &	 �     �� 5   
   " �6   .�5      ��  � y�$ Visible=�6+    5      �� 5       6   �� *Mess+$ TwoWay=� True6D   .a�5      ��  � y�$ 	Collapsed=�63   5      5      �� 5   
   " �6   .�5      ��  � y�$ Visible=�6+    5      �� 5       6   �� *Mess+$ TwoWay=�	 False6D   .a�5      ��  � y�$ 	Collapsed=�63   5      5      5      .��5      � -   5        	 �Name$	 Chart��5      
 � RowDefinitions
 5    
   �� 5!      $
��0.2* �6   �� 5"      $
��0.2* �6   �� 5#      $
��0.2* �6   �� 5$      $��2* �6   .+�5(   
   �� $��
Отчёт��6   $��0��6    $��Times New Roman)�6-   $
��Bold"�6J   $��24(�6\   $��Center=�6j   $��0 10 0 0q�6�   �� 5)   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   .+�5*      �� $*��$Выручка за период с ��6   $��Times New Roman)�63   $
��Bold"�6P   $��24(�6b   $��Center=�6p   (  "System.Windows.Controls.DatePicker  5+      $	��Top=�6   $	��180��6�      SelectedDate 62   �� *	DateStart+$ TwoWay=� �� UpdateSourceTrigger$ 	LostFocus=�6�   �� 5,      $�� по ��6   $��1��6#   $��Times New Roman)�60   $
��Bold"�6M   $��24(�6_   $��Center=�6m     5-      $	��Top=�6    61   �� *	DateEnd+$ TwoWay=�$ 	LostFocus=�6�   5.        LiveCharts.Wpf.PieChart  5/   
   $��3��6   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6M   $	��600��6�   $	��600��6�   $��30 0 0 0q�6�   $��Center=�6�      SeriesColors 6$   �� *ColorCollection+   Series 6d   �� *
Proceeds+51      �� 52   
   $��3��6   $��Закрыть��6>   $	��150��6Q   $��Right=�6`   $��Bottom=�6|   $��	0 0 20 20q�6�     MaterialDesignFlatButton#���  6�   $��Times New Roman)�6�   $
��Bold"�6�   $��2q�6  
��� �����6   �� *CloseWindow+6   �� 55   
   $��2��6   $��Times New Roman)�6:   $��18(�6W   
���  ��$��0 0 0 0q�6v   $��Center=�6�   $
��Wrap=�6�   ��6!   �� *	Message+6�   57      58      