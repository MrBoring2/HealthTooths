   M S B A M L   `   `   `  ���� G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  $    HealthyTeeth.Views.LoginWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:HealthyTeeth.Views     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a@material1http://materialdesigninxaml.net/winfx/xaml/themes  _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml    � 
ResizeMode$  NoResize=� � Icon$0 */HealthyTeeth;component/Resources/logo.ico�� � WindowStartupLocation$ CenterScreen=� � Title$8 2Здоровые зубы | Авторизация��$	��550��$	��500��.��� 
����ح�.+�3  -MaterialDesignExtensions.Controls.BusyOverlay     IsBusy ��  �� Path$ IsBusy�   Progress �� $ Progress�#  MaterialDesignThemes.Wpf.Card  $��50,50q�.���� $��Center=�$��Center=�.+��� .+��� $0��*/HealthyTeeth;component/Resources/logo.png��$	��100��$	��100��$��0,0,0,10q��� $��Авторизация��$��Center=�$��Center=�$��30(�$��0,0,0,40q��� $��1q�
����ح� �� CornerRadius$ 5��._���  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 AccountOutline=�$��50��$��50���� $��20(�$
��Left=�$��Center=�)  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 
Логин��$��5q�$	��250������ *Login+�� $��0,5,0,0q�$��1q�
����ح�$ 5��._��� $ 
Horizontal=�.+�  $	 PasswordOutline=�$��50��$��50��G� -    G�Name$ passwordText��$��20(�$
��Left=�$��Center=�$
 Пароль��$��5q�$	��250���� -    ��Name$ LoginButton��$��
Войти��
�������$��	0,15,0,50q�{��� *IsLoginEnabled+