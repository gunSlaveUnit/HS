   M S B A M L   `   `   `  ����  HS+    %HS.Views.Windows.Creation.NewRoomType   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Create a room type��5	   	   $	��500��6$   $	��400��61    � WindowStartupLocation$ CenterScreen=�6=    � DataContext 5   	   �� *NewRoomTypeViewModel+   Locator �� Source# [   J� InputBindings 5
      �� 5   
    �� 	Modifiers$ Controlf�6   
 �� Key$ Q��6)     CloseAppCommand �� Command# [ 5      .��5      �� $��20q�6   $��Center=�6   $	��300��5      .+�5   
   �� $��40(�6   $��Hotel��6"   61   �� 5   
   $��20(�6   $;��5Add a new type of room for the comfort of our clients��6"   6a   �� 5   
   $��0 70 0 0q�6   .+�5      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Title��6   $��15(�61   $	��200��6?   $��0 0 0 10q�5      .  (MaterialDesignThemes.Wpf.TextFieldAssist	   UnderlineBrush
	 ��  ���5   K   �� *Title+5   W   �� 5      $ Capacity��6   $��15(�64   $	��200��6B   $��0 0 0 10q�5      
	 ��  ���5   N   �� *
Capacity+5   W   �� 5      $ Cost per hour��6   $��15(�69   $	��200��6G   $��0 0 0 10q�5      
	 ��  ���5   S   �� *CostPerHour+5   W   �� 5      $ Cost per day��6   $��15(�68   $	��200��6F   $��0 0 0 10q�5      
	 ��  ���5   R   �� *
CostPerDay+5   W   �� 5      $ Description��6   $��15(�67   $	��200��6E   $��0 0 0 10q�5      
	 ��  ���5   Q   �� *Description+5   W   �� 5      
����  �
����  �$	��120��5      $��0 50 0 0q�6!   $��20(�5      $��Create��6#   $��40��64   
���������5   3   �� *CreateNewRoomTypeCommand+5   @   5       5!      5"      