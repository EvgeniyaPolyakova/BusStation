   M S B A M L   `   `   `  ����F  BBus_Station, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Bus_StationBus_Station  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	       Bus_Station.FindTicket   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Bus_Station     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  Найти билет��5   
   $	��460��6   $	��600��6+   $	��375��68   $	��450��6H    � 	Resources 5         validationFailed �� Orientation  show �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Mode	 �� Value  hide��%  &	        &	     &	 �    '�� �    '�� a    '��      �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� 
���  ��$��1q�6+   ._�5      �� 5      �� 5      
���  ��$��20(�6-   $
��Bold"�6;   XVСтоимость остановки больше стоимости маршрута6|   5      5      �� 5      " ��6!   .�5      ��  � y�$ Visible=�6/    5      �� 5       6"   �� *Mess+$ TwoWay=�	 True6H   .a�5      ��  � y�$ 	Collapsed=�67   5      5      �� 5      " ��6!   .�5       ��  � y�$ Visible=�6/    5!      �� 5"       6"   �� *Mess+$ TwoWay=�		 False6H   .a�5#      ��  � y�$ 	Collapsed=�67   5$      5&      �� 5(   
   " ��6   .�5)      ��  � ��$ Times New Roman)�63   �� 5*       � ��$ 18(�61   �� 5+       � ��$
 Bold"�63   5,      �� 5.   
   " ��6   .�5/      ��  � ��$ Times New Roman)�63   �� 50       � ��$ 12(�61   �� 51       � ��$
 Bold"�63   52      �� 53   
   " ��6   .�54      ��  � �� �#84848463   �� 55       � ��$ Times New Roman)�63   �� 56       � ��$ 18(�61   �� 57       � ��$
 Bold"�63   58      5:      .��5;      � 
 � RowDefinitions
 5<   
   �� 5=      $��0.15* �6   �� 5>      $
��0.1* �6   �� 5?      $��0.85* �6   �� 5@      $
��0.2* �6    � ColumnDefinitions 5C   
   �� 5D      $
��0.4* �6   �� 5E      $
��0.6* �6   .+�5H   
   �� $��0��6   $��0��6"   $��2��62   $��Center=�6F   .+�5I      �� $��Найти билет��6   $��Center=�6,   $	��174��6H   $��35��6W   $��26(�6f   5J      �� 5L   
   $��0��6   $��0��6   $��2��6.   $-��'Сменить пользователя��6a   $	��270��6�   $��0,6,0,0q�6�   $	��Top=�6�     MaterialDesignFlatButton#���  6�   $��Times New Roman)�6�   $
��Bold"�6	  
��� ���$��Right=�60  ��6B   �� *
ChangeUser+60  �� 5N   
   $��1��6   $��0��6!   $��2��61   $��Times New Roman)�6^   $��18(�6{   
���  ��$��0 0 0 0q�6�   $��Center=�6�   ��6E   �� *	Message+6�   �� 5P   
   $��2��6   $��0��6"   $��Center=�62   .+�5Q      �� $'��!Пункт отправления��6   $	��150��61   $��35��6@   �� 5R       �� 
IsEditable . $	��160��6�   $��25��6�    �� DisplayMemberPath$
 Name��6�   ��6   �� *StartCities+ �� SelectedValue 6;   �� *SelectStartCity+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5S      $!��Пункт прибытия��6   $	��150��6.   $��35��6=   �� 5T       . $	��170��6�   $��25��6�   $
 Name��6�   ��6   �� *	EndCities+ 6:   �� *SelectEndCity+$ PropertyChanged=�6�   (  "System.Windows.Controls.DatePicker  5U      $	��170��6_   $��0,10,0,0q�6n      SelectedDate 6   �� *DepartureDate+$ 	LostFocus=�5V      �� 5W      $%��Число пассажиров��6   $	��150��61   $��35��6@   �� 5X        MaterialDesignTextBox#��[ 6    �� TextWrapping$
 Wrap=�6F   $	��170��6Z   .��6i   ��5Y      �� 5Z       �� Path$ PassengerNumber�6   $ PropertyChanged=�65    �� ValidationRules 5[      5  /System.Windows.Controls.DataErrorValidationRule  5\      5^      .��5_       5`      �� 5b      $��
Найти��62   $��Center=�6B   $	��120��6`   #���  6o   $��Times New Roman)�6�   $
��Bold"�6�   $��2q�6�   
��� ���$��18(�6�   $��0,10,0,0q�6  ��6   �� *
FindTrip+6  5c      &   System.Windows.Controls.DataGrid  5i   
   -   5        $
��grid��5i      $��2��6   $��1��6,      AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . ��6<   �� *AvailableTrips+ �� SelectedItem 6�   �� *SelectedTrip+.  (System.Windows.Interactivity.Interaction   Triggers 5j      /  )System.Windows.Interactivity.EventTrigger  5k         	EventName$ SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5l      6  0System.Windows.Interactivity.InvokeCommandAction     Command 5m      �� $$ DataContext.ChangeSelectedTrip� �� RelativeSource ��  �� AncestorType"     CommandParameter 5n      ��  �� ElementName$
 grid��$ SelectedItem�5o          Columns  5q      0  *System.Windows.Controls.DataGridTextColumn  5r      ,	  &System.Windows.Controls.DataGridColumn! 	  Header$'! !Время отправления��6%   " 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$" *
 6^   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6@   �� $
 Time�6^     5s      $ ! Стоимость, руб��6%   $" *
 6[   # 6=   �� $
 Cost�6[   5u      �� 5w   
   $��3��6   $��1��6   $��Оформить��6J   $	��120��6]   #���  6l   $��Times New Roman)�6�   $
��Bold"�6�   $��2q�6�   
��� ���$��18(�6�   $
��Left=�6  ��6.   �� *	Arrange+6  �� 5x   
   $��3��6   $��1��6   $��Закрыть��6N   $	��150��6a   #���  6p   $��Times New Roman)�6�   $
��Bold"�6�   $��2q�6�   
��� ���$��18(�6�   $��0 0 10 0q�6	  $��Right=�6  ��6.   �� *CloseWindow+6  5y      5z      