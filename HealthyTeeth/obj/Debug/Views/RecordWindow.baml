   M S B A M L   `   `   `  ����G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  5   	   %    HealthyTeeth.Views.RecordWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HealthyTeeth.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml  5   	     � 
ResizeMode$  NoResize=�5   =    � WindowStartupLocation$ CenterScreen=�5	       � Title$? 9Здоровые зуюы | Записать заявку��5
   	   $	��598��61   $��605.01��6>    � Icon$0 */HealthyTeeth;component/Resources/logo.ico��6M   .��5      � 
����ح�.+�5   
   #  MaterialDesignThemes.Wpf.Card  $��20,20,20,60q�6   .��5      �  � RowDefinitions 5      �� 5      $��40 �6$   �� 5      $	��80* �6$   �� 5      $	��80* �6$   �� 5      $	��80* �6$   �� 5      $	��80* �6$   .+�5      �� $#��Карточка заявки��6   $��20(�63   $��Center=�6A   $��Center=�6^   $��154,6,153,6q�6y   $��28��6�   $	��194��6�   �� 5      $��1��6   .+�5      �� $��Клиент��6    $��10q�6.   $��16(�6:   � 5      .+�5      ��  �� 
IsReadOnly . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$% Выберите клиента��6T   $��
10,0,120,0q�6�   $��14(�6�   ��64   �� *ClientFullName+6�   �� 5      -   5         ��Name$ SelectClient��5   !   $��Выбрать��67   
�������$��Right=�6\   $��0,0,10,0q�6x   $	��105��6�   6�   5      5      �� 5      $��2��6   .+�5      �� $��Доктор��6    $��10q�6.   $��16(�6:   � 5       .+�5!      ��  . $% Выберите доктора��6T   $��
10,0,120,0q�6�   $��14(�6�   ��64   �� *DoctorFullName+6�   �� 5"      -   5        $��SelectDoctor��5"   !   $��Выбрать��65   
�������$��Right=�6Z   $��0,0,10,0q�6v   $	��105��6�   6�   5#      5$      �� 5&      $��3��6   .+�5'      �� $��День заявки��6    $��10q�63   $��16(�6?   � 5(      .+�5)      (  "System.Windows.Controls.DatePicker  $ Выберите день��6I   $��	10,0,10,0q�6r   $��14(�6�      SelectedDate 6%   �� *
RecordDate+6�   5*      5+      �� 5-      $��4��6   .+�5.      �� $��Время заявки��6    $��10q�64   $��16(�6@   � 5/      .+�50      �� $
��10,0q�6%   	 �� Orientation$	 
Horizontal=�63   .+�51      �� $��16(�6'   $ Час��66   $	��0,5q�6�   
   
IsFloating
 . ��6U   �� *Hours+ �� SelectedItem 6s   �� *SelectedHour+6�   �� 52      $��16(�6'   $ Минуты��65   $��5q�6W   
 . ��6b   �� *	Minutes+ 6�   �� *SelectedMinute+6�   53      55      56      57      58      � 59   
   $��Bottom=�6   .+�5:      �� -   5        $ CreateRecord��5:      
�������$��Оформить��6>   $
��Left=�6Q   $��20,10,10,10q�6l   $	��150��6�   6�   �� 5;      -   5        $
 Back��5;      
�������$��
Назад��66   $��Right=�6F   $��20,10,20,10q�6b   $	��150��6w   6�   5<      5=      5>      