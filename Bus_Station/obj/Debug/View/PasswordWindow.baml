   M S B A M L   `   `   `  ����F  BBus_Station, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Bus_StationBus_Station  5   	        Bus_Station.PasswordWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Bus_Station     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$   Вход в систему��5	      $	��250��6   $	��190��6)   $	��250��69   $	��300��6H    � 	Resources 5
       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��
 �����63   �� 5       � �� �#84848463   �� 5       � ��$ Times New Roman)�63   �� 5       � ��$ 18(�61   �� 5       � ��$
 Bold"�63   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.6* �6   �� 5      $
��0.3* �6   .+�5   
   �� $��0��6   $"��Войти в систему��6!   $
��Bold"�68   $��Bottom=�6J   $��Center=�6e   $��16(�6�   �� 5   
   $��1��6   $��Times New Roman)�6:   $��18(�6W   
���  ��$��Center=�6v   $
��Bold"�6�   $��0 10 0 0q�6�   ��6!   �� *	Message+6�   �� 5   
   $��2��6    �� Orientation$ Vertical=�6"   .+�5      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$% Имя пользователя��6^    %  !MaterialDesignFloatingHintTextBox#��[  6�   $��Center=�6�   $	��140��6�    �� TextWrapping$
 Wrap=�6�   ��6   �� *Login+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=�6�   �� 5       $ Пароль��6a   #��[  6�   $��Center=�6�   $	��140��6�   $
 Wrap=�6�   ��6   �� *
Password+$	 PropertyChanged=�$
 TwoWay=�6�   5"      �� 5#   
   -   5         ��Name$ InputButton��5#      $��3��6   $��
Войти��6L    �� 	IsDefault . $��Center=�6m   $��Center=�6�   $	��100��6�   $��30��6�     MaterialDesignFlatButton#���  6�   $��2q�6�   
��� ���$��2��6   ��63   �� *Auth+6   5%      5&      