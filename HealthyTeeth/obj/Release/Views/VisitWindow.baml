   M S B A M L   `   `   `  ���� G  CHealthyTeeth, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HealthyTeeth.ViewsHealthyTeeth.Views  $    HealthyTeeth.Views.VisitWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:HealthyTeeth.Views     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a@material1http://materialdesigninxaml.net/winfx/xaml/themes  _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml    � Title$I  CЗдоровые зубы | Оформление посещения��$	��550��$
��1105��$	��550��$
��1105�� � Icon$0 */HealthyTeeth;component/Resources/logo.ico��.��� 
����ح� � ColumnDefinitions �� $
��140* ��� $
��230* �.+�#  MaterialDesignThemes.Wpf.Card  $��15q�.��� $��0�� � RowDefinitions �� $��35 ��� $	��96* ��� $	��92* ��� $	��97* ��� $
��119* ��� $��50 �.+��� $#��Основные данные��$��Center=�$	��Top=�$��20(�$��5q��� $��1��.+��� $'��!Выберите пациента��$��5q�$��16(�� .+���  �� 
IsReadOnly . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$, &Введите ФИО пациента��$��5,5,5,5q�$��14(����� *ClientFullName+�� $��2��.+��� $!��Дата посещения��$��5q�$��16(�(  "System.Windows.Controls.DatePicker  {�.  $��5q�$ Выберите дату��$��14(�   SelectedDate �� *	VisitDate+�� $��3��.+��� $#��Время посещения��$��5q�$��16(�)  #MaterialDesignThemes.Wpf.TimePicker  -     Name$	 das��{�.  $��5q�$! Выберите время��$��14(�   SelectedTimeFormat$
 Long=�	   SelectedTime	 �� *	VisitDate+
 �� Mode$
 TwoWay=��� $��4��.+��� $��Тип посещения��$��5q�$��16(��� $��5q�$0 *Выберите тип посещения�� �� DisplayMemberPath$ VisitTypeName��$��14(����� *
VisitTypes+ �� SelectedItem �� *SelectedType+� $��5�� �� $
��100* ��� $
��100* �.+��� -    ��Name$ CreateVisit��$	��5,9q�$)��#Оформить посещение��
�������$��0���� -   $ Cancel��$	��5,9q�$��Отмена��
�������$��1��  $��1��$��15q�.���  �� $
��290* ��� $
��250* � �� $��85 ��� $
��307* ��� $��50 �.+��� $@��:Потраченные раходные материалы��$��20(�$��Center=�$��5q�$	��Top=�$��2���� $��
Склад��$��
15,30,0,31q�$��14(��� $��14(�$ StorageName��$��
15,50,10,5q����� *
Storages+ �� *SelectedStorage+�� $)��#Список расходников��$��1��$��14(�$��Center=�$	��Top=��� $��Disabled=� �� SelectionMode$ Single=�   listViewItemStype#��[  $��1��$��0��$��5,20,5,5q�$��1��  consumablesToAdd#��[ $��Stretch=� �� *SelectedConsumable+���� *DisplayedConsumables+�� $@��:Список потраченных расходников��$��1��$��1��$��14(�$��Center=�$	��Top=��� $��Disabled=�$��1��$��1��$��5,20,5,5q�$��1��$ Single=�#��[    spendConsumablesList#��[ $��Stretch=� �� *SelectedSpendConsumable+���� *SpendedConsumables+�� -   $ 	AddToList��$&�� Добавить в список��$��3��$��0��$��5q�
��������� -   $ RemoveFromList��$&�� Удалить из списка��$��3��$��1��$��5q�
�������