   M S B A M L   `   `   `  ����G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  5   	   $    HealthyTeeth.Views.VisitWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HealthyTeeth.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml  5   	     � Title$I  CЗдоровые зубы | Оформление посещения��5
   	   $	��550��66   $
��1105��6C   $	��550��6P   $
��1105��6`    � Icon$0 */HealthyTeeth;component/Resources/logo.ico��5   	   .��5      � 
����ح� � ColumnDefinitions 5   
   �� 5      $
��140* �6   �� 5      $
��230* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��15q�6   .��5      � $��0��6    � RowDefinitions 5      �� 5      $��35 �6$   �� 5      $	��96* �6$   �� 5      $	��92* �6$   �� 5      $	��97* �6$   �� 5      $
��119* �6$   �� 5      $��50 �6$   .+�5      �� $#��Основные данные��6   $��Center=�63   $	��Top=�6P   $��20(�6h   $��5q�6v   �� 5      $��1��6   .+�5      �� $'��!Выберите пациента��6    $��5q�69   $��16(�6D   � 5      .+�5      ��  �� 
IsReadOnly . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$, &Введите ФИО пациента��6T   $��5,5,5,5q�6�   $��14(�6�   ��64   �� *ClientFullName+6�   5       5!      �� 5"      $��2��6   .+�5#      �� $!��Дата посещения��6    $��5q�66   $��16(�6A   (  "System.Windows.Controls.DatePicker  5$      {�.  $��5q�64   $ Выберите дату��6?   $��14(�6�      SelectedDate 6h   �� *	VisitDate+6�   5%      �� 5&      $��3��6   .+�5'      �� $#��Время посещения��6    $��5q�67   $��16(�6B   )  #MaterialDesignThemes.Wpf.TimePicker  5(      -   5          Name$	 das��5(   *   {�.  $��5q�6J   $! Выберите время��6U   $��14(�6�      SelectedTimeFormat$
 Long=�6�   	   SelectedTime	 6   �� *	VisitDate+
 �� Mode$
 TwoWay=�6�   5)      �� 5*      $��4��6   .+�5+      �� $��Тип посещения��6    $��5q�65   $��16(�6@   �� 5,      $��5q�6   $0 *Выберите тип посещения��6*    �� DisplayMemberPath$ VisitTypeName��6   $��14(�6�   ��6\   �� *
VisitTypes+ �� SelectedItem 6�   �� *SelectedType+6�   5-      � 5.      $��5��6    5/      �� 50      $
��100* �6+   �� 51      $
��100* �6+   .+�53      �� -   5         ��Name$ CreateVisit��53      $	��5,9q�63   $)��#Оформить посещение��6@   
�������$��0��6p    � Cursor$
 Hand��6�   �� 54      -   5        $ Cancel��54      $	��5,9q�6-   $��Отмена��6:   
�������$��1��6^   6n   55      56      57        58   
   $��1��6   $��15q�6(   .��59      �  5:      �� 5;      $
��290* �6'   �� 5<      $
��250* �6'    5>      �� 5?      $��85 �6$   �� 5@      $
��307* �6$   �� 5A      $��50 �6$   .+�5C      �� $@��:Потраченные раходные материалы��6   $��20(�6B   $��Center=�6P   $��5q�6m   $	��Top=�6x   $��2��6�   �� 5D      $��
Склад��6   $��
15,30,0,31q�6)   $��14(�6=   �� 5E      $��14(�6   $ StorageName��6J   $��
15,50,10,5q�6�   ��6)   �� *
Storages+ 6j   �� *SelectedStorage+6�   �� 5G      $)��#Список расходников��6   $��1��66   $��14(�6C   $��Center=�6Q   $	��Top=�6n   �� 5H      $��Disabled=�6    �� SelectionMode$ Single=�6Q      listViewItemStype#��[  6�   $��1��6�   $��0��6�   $��5,20,5,5q�6�   $��1��6�     consumablesToAdd#��[ 69  $��Stretch=�6j   6h   �� *SelectedConsumable+��6  �� *DisplayedConsumables+6j  �� 5I      $@��:Список потраченных расходников��6   $��1��6B   $��1��6O   $��14(�6_   $��Center=�6m   $	��Top=�6�   �� 5J      $��Disabled=�6   $��1��6Q   $��1��6^   $��5,20,5,5q�6n   $��1��6�   $ Single=�6�   #��[  6�     spendConsumablesList#��[ 6=  $��Stretch=�6r   6�   �� *SelectedSpendConsumable+��6  �� *SpendedConsumables+6r  �� 5K      -   5        $ 	AddToList��5K      $&�� Добавить в список��6,   $��3��6H   $��0��6U   $��5q�6e   
�������6�   �� 5L      -   5        $ RemoveFromList��5L      $&�� Удалить из списка��61   $��3��6M   $��1��6Z   $��5q�6j   
�������6�   5M      5N      5O      5P      