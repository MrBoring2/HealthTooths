   M S B A M L   `   `   `  ����G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  5   	   $    HealthyTeeth.Views.LoginWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HealthyTeeth.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml  5   	     � 
ResizeMode$  NoResize=�5       � Icon$0 */HealthyTeeth;component/Resources/logo.ico��5	       � WindowStartupLocation$ CenterScreen=�5
   	    � Title$8 2Здоровые зубы | Авторизация��5   	   $	��550��6-   $	��500��6:   .��5      � 
����ح�.+�5   
   3  -MaterialDesignExtensions.Controls.BusyOverlay     IsBusy 6   ��  �� Path$ IsBusy�   Progress 5      �� $ Progress�#  MaterialDesignThemes.Wpf.Card  5   
   $��50,50q�6   .��5      �� $��Center=�6   $��Center=�66   .+�5      �� .+�5      �� $0��*/HealthyTeeth;component/Resources/logo.png��6   $	��100��6P   $	��100��6\   $��0,0,0,10q�6i   �� 5      $��Авторизация��6    $��Center=�63   $��Center=�6N   $��30(�6k   $��0,0,0,40q�6y   �� 5      $��1q�6   
����ح� �� CornerRadius$ 5��6I   ._�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 AccountOutline=�60   $��50��6F   $��50��6Q   �� 5      $��20(�6&   $
��Left=�6K   $��Center=�6f   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 
Логин��6�   $��5q�6�   $	��250��6�   ��64   �� *Login+6�   5      5      �� 5      $��0,5,0,0q�6   $��1q�6.   
����ح�$ 5��6Z   ._�5      �� $ 
Horizontal=�6%   .+�5        $	 PasswordOutline=�60   $��50��6G   $��50��6R   G� 5      -   5         G�Name$ passwordText��5   *   $��20(�6@   $
��Left=�6N   $��Center=�6i   $
 Пароль��6�   $��5q�6�   $	��250��6�   5      5      �� 5!      -   5         ��Name$ LoginButton��5!      $��
Войти��62   
�������$��	0,15,0,50q�6z   {�6U   �� *IsLoginEnabled+6�   5"      5#      5%      5&      5'      