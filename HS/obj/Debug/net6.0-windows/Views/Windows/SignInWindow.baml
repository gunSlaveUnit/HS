   M S B A M L   `   `   `  ����  HS&     Hotel.Views.Windows.SignInWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SFontAwesome5.Net, Version=2.1.4.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8.fa%http://schemas.fontawesome.com/icons/  5   	     � Title$  Login��5
   	   $	��550��6   $	��400��6$    � WindowStartupLocation$ CenterScreen=�60    � DataContext 5	   	   �� *SignInViewModel+   Locator �� Source# [   J� InputBindings 5      �� 5   
    �� 	Modifiers$ Controlf�6   
 �� Key$ Q��6)     CloseAppCommand �� Command# [ 5      �� 5   
   $ Enter��6    5      �� *SignInCommand+.��5      �� $��20q�6   $��Center=�6   $��Center=�68   $	��300��5      .+�5   
   �� $��45(�6   $��	Rievierra��6"   65   �� 5   
   $��25(�6   $&�� Добро пожаловать,��6"   6=   �� 5   
   
�������$��20(�6*   $5��/войдите, чтобы продолжить��68   6[   �� 5   
   $��0 50 0 0q�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5        FontAwesome5.ImageAwesome  	   Icon$	 
Solid_User=�6"   $��20��64   6B   �� 5      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 
Логин��6   $��20(�65   $	��220��6C   $��40��6O   $��
20 0 20 20q�5      ��5   [   �� *Login+5   1   5      �� 5      $ 
Horizontal=�6   .+�5        $	 	Solid_Key=�6"   $��20��63   6A   �� 5      $
��20 0q�6   $
 Пароль��6(   $��20(�6D   $	��220��6R   $��40��6^   ��5      �� *
Password+66   5       �� 5"      $��Center=�61   $��15(�6N   $
��0 10q�5#      ��5"      �� *	Message+��5$      �� *MessageColor+6>   �� 5&      $	��120��6   $��0 50 0 0q�6!   $��30(�5'      $��
Войти��6#   $��50��63   
���������5&   3   �� *SignInCommand+5'   ?   5(      �� 5*   
   $��0 35 0 0q�6   $ 
Horizontal=�6'   $��Center=�6@   .+�5+      �� $��20(�6   $��Нет аккаунта?��6&   6=   �� 5,      -   5        $��SignUpClickableText��5,      $��20(�63   $
��Bold"�6A   $��Регистрация��6S   $��10 0 0 0q�6f    5/      d� 50       d� MouseAction$ 	LeftClicke�52       51      �� *OpenNewSignUpWindowCommand+52   3   54      55      56      57      