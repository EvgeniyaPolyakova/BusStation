   M S B A M L   `   `   `  ����F  BBus_Station, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Bus_StationBus_Station  5   	       Bus_Station.Report   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Bus_Station     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Icon$q  kC:\Users\user\Desktop\ИГЭУ\3 курс\Конструирование ПО\АВТОВОКЗАЛ\Icon.jpg��5       � Title$ 
Отчет��5
   	   $	��500��6   $	��800��6$   $	��400��61   $	��600��6A    � 	Resources 5       �� 
TargetType �� Property �� Value��%x  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$ Times New Roman)�63   �� 5       � ��$ 18(�61   �� 5       � ��$
 Bold"�63   5      �� 5   
   " ��6   .�5      ��  � ��
 �����63   �� 5       � ��$ Times New Roman)�63   �� 5       � ��$ 18(�61   �� 5       � ��$
 Bold"�63   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��0.15* �6   �� 5      $��0.10* �6   �� 5      $
��0.2* �6   �� 5      $��0.85* �6    � ColumnDefinitions 5"   
   �� 5#      $��0.25* �6   �� 5$      $��0.25* �6   �� 5%      $��0.25* �6   �� 5&      $��0.25* �6   .+�5*   
   �� $��0��6   $��0��6    $��4��6-   $��Center=�6A   $��
Отчёт��6^   $��Center=�6p   $	��174��6�   $��35��6�   $��26(�6�   �� 5,   
   $��0��6   $��1��6    $��Откуда��6-   $��Center=�6?   $	��174��6\   $��35��6k   �� 5-   
   $��1��6   $��1��6    $��Куда��6-   $��Center=�6>   $	��174��6\   $��35��6k   �� 5.   
   $��2��6   $��1��6    $��Дата��6-   $��Center=�6>   $	��174��6\   $��35��6k   �� 50   
    �� DisplayMemberPath$ StartCities��6�   	 �� 
IsEditable	 . $��0��6�   $��2��6�   $	��120��6�   $��23��6�   $��30��6�   $��10,0,8,5q�6  ��6   �� *StartCities+
 �� SelectedValue
 67   �� *SelectStartCity+ �� UpdateSourceTrigger$ PropertyChanged=�6  �� 51   
   $ 	EndCities��6�   	 . $��1��6�   $��2��6�   $	��120��6�   $��23��6�   $��30��6�   $��0,0,8,5q�6�   ��6   �� *	EndCities+
 65   �� *SelectEndCity+$ PropertyChanged=�6�   (  "System.Windows.Controls.DatePicker  52   
   $��2��6S   $��2��6c   $	��145��6p   $��30��6   $��23��6�      SelectedDate 6   �� *Date+$ 	LostFocus=�6�   &   System.Windows.Controls.DataGrid  54   
   -   5        $
��grid��54      $��0��6   $��3��6/   $��3��6<      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $��10,0,0,0q�6�   ��6P   �� *AvailableTrips+ �� SelectedItem 6�   �� *
Selected+   Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$' !Пункт отправления��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 1.2* 6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   ��  �� Path$ DeparturePlace�6h     57      $% Пункт назначения��6%   $
 1.2* 6e    6?   �� $ ArrivalPlace�6e     58      $  Стоимость, руб��6%   $ * 6[    6=   �� $
 Cost�6[     59      $# Продано билетов��6%   $
 1.2* 6g    6>   �� $ NumberOfTickets�6g   5;      �� 5<   
   $��3��6   $��2��6!   $��
Отчёт��6I   $��Center=�6Y   $��Center=�6w   $	��120��6�      MaterialDesignFlatButton#���   6�   $��Times New Roman)�6�   $
��Bold"�6�   $��2q�6  
��� �����6.   �� *Report+6  �� 5=   
   $��3��6   $��3��6!   $��График��6J   $��Center=�6[   $	��Top=�6y   $	��120��6�   $��0,0,0,0q�6�   $��2q�6�   #���   6�   $��Times New Roman)�6�   $
��Bold"�6  
��� �����6.   �� *	Diagram+6'  �� 5>   
   $��3��6   $��3��6!   $��Печать��6H   $��Center=�6Y   $��Bottom=�6w   $	��120��6�   $��0,0,0,10q�6�   $��2q�6�   #���   6�   $��Times New Roman)�6�   $
��Bold"�6  
��� �����6.   �� *Print+6)  5?      5@      