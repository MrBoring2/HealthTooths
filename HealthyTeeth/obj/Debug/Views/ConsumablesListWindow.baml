   M S B A M L   `   `   `  ����G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  5   	   .    (HealthyTeeth.Views.ConsumablesListWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HealthyTeeth.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml  5	   	     � WindowStartupLocation$  CenterScreen=�5       � Title$E ?Здоровые зубы | Список расходников��5
   	   $	��750��64   $	��970��6A   $	��750��6M   $	��970��6]    � Icon$0 */HealthyTeeth;component/Resources/logo.ico��6l   .��5      � 
����ح� � RowDefinitions 5   
   �� 5      $
��200* �6   �� 5      $��50 �6   �� 5      $	��150 �6   �� 5      $��50 �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��20q�6   $��1��6$   .��5      � .+�5      �� $��Center=�6   $��Center=�6:   y�6U   �� *EmptyVisibility+.+�5      �� $1��+/HealthyTeeth;component/Resources/empty.png��6   $	��200��6Q   $��Center=�6]   �� 5      $3��-Поиск не дал результатов��6    $��20(�6@   $��Center=�6N   5      �� 5      -   5         ��Name$ ConsumablesList��5      ��6~   �� *DisplayedConsumables+ �� SelectedItem 6�   �� *SelectedConsumable+ �� View 5      �� 5      P�5      �� 5   "   -   5        name��$��Название��5   ?    �� CellTemplate 5   &   �� 5   *    �� DataType" ��67   .R�5   .   �� $
��Wrap=�6X   ��68   �� *ConsumableName+6X   5    +   5"   #   �� 5#   "   -   5        type��$��Тип��5#   ?    5$   &   �� 5%   *   " ��67   .R�5&   .   �� ��68   �� *#!ConsumableType.ConsumableTypeName+5'   +   5)   #   �� 5*   "   -   5        cena��$��Цена��5*   ?    5+   &   �� 5,   *   " ��67   .R�5-   .   �� ��68   �� *Price+	 �� StringFormat$	 {0} руб.��5.   +   50   #   �� 51   "   -   5        
amount��$��Количество��51   A    52   &   �� 53   *   " ��67   .R�54   .   �� ��68   �� *TotalAmountInStorages+55   +   57   #   59      5;      5<      5>      �� 5@   
   -   5        $��PaginatorPanel��5@   .   
 �� Orientation$
 
Horizontal=�6   $��Center=�6D   $��1��6b   $��1��6o   .+�5A      �� -   5         ��Name$ ToFirst��5A      $��«��6=   $��0,7.5,0,7.5q�6I   
�������$��35��6q   $��50��6}   $��30(�6�      buttonTemplate#��[  6�   �� 5B      -   5        $ 	PagesList��5B   �   $��5,7.5q�6   $��Disabled=�6&     	paginator#��[ 6Z   $��Stretch=�6  $
��Auto��6  $��Stretch=�6e  $��Stretch=�6�   6�   �� *Paginator.SelectedPageNumber+��6-  �� *!Paginator.DisplayedPagesNumbers+��5C      �� 5D      .R�5E      �� $��Center=�65   $��Center=�6R   $��Italic$�6m   $��20��6�   $��45��6�   $��18(�6�    �� TextAlignment$ Center=�6�   ��6$   �� 6�   5F      ��5H      �� 5I      .R�5J      � 5K      5M      �� 5N      -	   5        $ ToLast��5N      $ Center=�6%   
�������$��»��6n   $��0q�6z   $��35��6�   $��50��6�   $��30(�6�   #��[  6�   5O        5Q   
   $��2��6   $��	20,5,20,5q�6%   .��5R      �  � ColumnDefinitions 5S      �� 5T      $
��285* �6'   �� 5U      $
��212* �6'   �� 5V      $
��255* �6'   .+�5X      �� $��
Поиск��6   $��5q�6)   $��16(�64   �� 5Y      $
��5,55q�6    �� TextWrapping$
 Wrap=�6e   $��16(�6y   $��Stretch=�6�   $��Center=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$= 7Введите название расходника...��6�   $��30��6�   ��6(   �� *Search+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5Z      $��Сортировка��6   $��1��6.   $��5q�6>   $��16(�6I   �� 5[       �� DisplayMemberPath$ Title��6h   $��1��6�   $
��5,55q�6�   $+ %Выберите сортировку��6�   $��16(�6�    6   �� *SelectedSort+��6A   �� *SortParameters+6�   � 5\      $��1��6   $��Bottom=�6'   $
��5,20q�6B   .+�5]      	� -
   5         	�Name$ 	Ascending��5]   "   $!��По возрастанию��65   $
��Left=�6N   $��14(�6i    	� 	GroupName$ A��6w   $��5q�6�    d� 	IsChecked 6�   �� *IsAscending+	� 5^      -   5        $ 
Descending��5^   "   $��По убыванию��66   $��Right=�6L   $��14(�6h   $ A��6v    6�   �� *IsDescending+5_      �� 5a      $��Тип��6   $��5q�6'   $��16(�62   $��2��6@   $��1��6P   �� 5b      $
��5,55q�6   $��2��6)   $ Выберите тип��6_   $��16(�6�   $��1��6�    69   �� *SelectedType+��6�   �� *Types+6�   5c      5d      �� 5e   
   -   5        $ AddNewConsumable��5e      $��3��6+   $��	0,8,20,10q�68   
�������$��Right=�6^   $	��182��6z   $)��#Добавить расходник��6�   $
��Auto��6�   �� 5f   
   -   5        $ EditConsumable��5f      $��3��6)   $��
0,8,207,10q�66   
�������$��Right=�6]   $	��214��6y   $3��-Редактировать расходник��6�   $
��Auto��6�    � Cursor$
 Hand��6�   �� 5g   
   -   5        $ RemoveConsumable��5g      $��3��6+   $��
0,8,426,10q�68   
�������$��Right=�6_   $	��184��6{   $'��!Удалить расходник��6�   $
��Auto��6�   �� 5h   
   -   5        $
 Back��5h      $��3��6   $��
0,10,778,8q�6,   
�������$��Right=�6S   $	��164��6o   $��
Назад��6{   $
��Auto��6�   $
 Hand��6�   5i      5j      