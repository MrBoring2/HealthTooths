   M S B A M L   `   `   `  ����G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  5   	   *    $HealthyTeeth.Views.ClientsListWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HealthyTeeth.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml  5	   	     � WindowStartupLocation$  CenterScreen=�5       � Title$? 9Здоровые зубы | Список клиентов��5
   	   $	��750��61   $
��1088��6>   $	��750��6K   $
��1088��6[    � Icon$0 */HealthyTeeth;component/Resources/logo.ico��6k   .��5      � 
����ح� � RowDefinitions 5   
   �� 5      $
��200* �6   �� 5      $��50 �6   �� 5      $	��150 �6   �� 5      $��50 �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��20q�6   $��1��6$   .��5      � .+�5      �� $��Center=�6   $��Center=�6:   y�6U   �� *EmptyVisibility+.+�5      �� $1��+/HealthyTeeth;component/Resources/empty.png��6   $	��200��6Q   $��Center=�6]   �� 5      $3��-Поиск не дал результатов��6    $��20(�6@   $��Center=�6N   5      �� 5      -   5         ��Name$ ClientsList��5      ��6r   �� *DisplayedClients+ �� SelectedItem 6�   �� *SelectedClient+ �� View 5      �� 5      P�5      �� 5   "   -   5        fio��$��ФИО��5   >    �� CellTemplate 5   &   �� 5   *    �� DataType" ��67   .R�5   .   �� ��68   �� *ClientFullName+5    +   5"   #   �� 5#   "   -   5        
gender��$��Пол��5#   A    5$   &   �� 5%   *   " ��67   .R�5&   .   �� ��68   �� *ClientGender+5'   +   5)   #   �� 5*   "   -   5        passport��$'��!Паспортные данные��5*   C    5+   &   �� 5,   *   " ��67   .R�5-   .   �� ��68   �� *
Passport+5.   +   50   #   �� 51   "   -   5        phoneNumber��$!��Номер телефона��51   F    52   &   �� 53   *   " ��67   .R�54   .   �� ��68   �� *PhoneNumberText+55   +   57   #   59      5;      5<      5>      �� 5@   
   -   5        $��PaginatorPanel��5@   .   	 �� Orientation$	 
Horizontal=�6   $��Center=�6D   $��1��6b   $��1��6o   .+�5A      �� -   5        
 ��Name$
 ToFirst��5A      $��«��6=   $��0,7.5,0,7.5q�6I   
�������$��35��6q   $��50��6}   $��30(�6�      buttonTemplate#��[  6�   �� 5B      -   5        $ 	PagesList��5B   �   $��5,7.5q�6   $��Disabled=�6&     	paginator#��[ 6Z   $��Stretch=�6  $
��Auto��6  $��Stretch=�6e  $��Stretch=�6�   6�   �� *Paginator.SelectedPageNumber+��6-  �� *!Paginator.DisplayedPagesNumbers+��5C      �� 5D      .R�5E      �� $��Center=�65   $��Center=�6R   $��Italic$�6m   $��20��6�   $��45��6�   $��18(�6�    �� TextAlignment$ Center=�6�   ��6$   �� 6�   5F      ��5H      �� 5I      .R�5J      � 5K      5M      �� 5N      -	   5        $
 ToLast��5N      $ Center=�6%   
�������$��»��6n   $��0q�6z   $��35��6�   $��50��6�   $��30(�6�   #��[  6�   5O        5Q   
   $��2��6   $��	20,5,20,5q�6%   .��5R      �  � ColumnDefinitions 5S      �� 5T      $
��486* �6'   �� 5U      $
��205* �6'   �� 5V      $
��349* �6'   .+�5X      �� $��
Поиск��6   $��5q�6)   $��16(�64   �� 5Y      $
��5,55q�6   $��16(�6e   $��Stretch=�6s   $��Center=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите ФИО...��6�   $��30��6�   ��6(   �� *Search+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5[      $��1��6   .+�5\      �� $&�� Сортировка по ФИО��6    $��16(�69   $��5q�6G   	� 5]      -
   5         	�Name$ 	Ascending��5]   "   $!��По возрастанию��65   $��16(�6N    	� 	GroupName$ A��6�    d� 	IsChecked 6\   �� *IsAscending+6�   	� 5^      -   5        $ 
Descending��5^   "   $��По убыванию��66   $��16(�6L   $ A��6�    6Z   �� *IsDescending+6�   5_      �� 5b      $��Пол��6   $��5q�6'   $��16(�62   $��2��6@   �� 5c      $
��5,55q�6   $��2��6)   $ Выберите пол��6a   $��16(�6�    69   �� *SelectedGender+��6�   �� *	Genders+5d      5e      �� 5h   
   -   5        $
 Select��5h      $��3��6!   $��
189,8,0,10q�6.   
�������$
��Left=�6}   $	��165��6�   $#��Выбрать клиента��6�   $
��Auto��6�   y�6B   �� *SelectVisibility+6�   �� 5i   
   -   5        $
 AddNewClient��5i      $��3��6'   $��	0,8,20,10q�64   
�������$��Right=�6Z   $	��164��6v   $%��Добавить клиента��6�   $
��Auto��6�   �� 5j   
   -   5        $
 
EditClient��5j      $��3��6%   $��
0,8,189,10q�62   
�������$��Right=�6Y   $	��200��6u   $/��)Редактировать клиента��6�   $
��Auto��6�   �� 5k   
   -   5        $
 RemoveClient��5k      $��3��6'   $��
0,8,394,10q�64   
�������$��Right=�6[   $	��164��6w   $#��Удалить клиента��6�   $
��Auto��6�   �� 5l   
   -   5        $

 Back��5l      $��3��6   $��	20,8,0,10q�6,   
�������$
��Left=�6R   $	��164��6m   $��
Назад��6y   $
��Auto��6�   5m      5n      