   M S B A M L   `   `   `  ����F  BTextHandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TextHandlerTextHandler  5   	   E ATextParser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:TextParser;assembly=TextParser
TextParser 5   	       TextHandler.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1textHandlerclr-namespace:TextHandler     5   	   C
textParser,clr-namespace:TextParser;assembly=TextParser     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	     � Title$  
MainWindow��5
   	   $	��350��6   $	��525��6)    � DataContext 5      "   TextHandler.ViewModelHandler  5   
    � 	Resources 5       �� Source�� 5   	   $ ParserStyles.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��2* �6   .+�5   
   � $��0��6   $��Stretch=�6    � RowDefinitions 5      �� 5      $��* �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��Disabled=�6L   ��6$   �� *smallDictionary+ 5       �� 
TargetType �� Property �� Value	 �� RelativeSource��%�   '��       �� 5      " ��6   .�5      ��  � �� 64   �� *OrderByCommand+�� 5        � �� 6=   �� 	 �� *Self+5!      5"      
 �� View
 5#      �� 5$      .P�5%      �� $)��#Каноническая форма��6S    �� DisplayMemberBinding 6)   �� *
mainword+6S   �� 5&      $��Общая частота��6T    6)   �� *	frequence+6T   �� 5'      $��Общая частота��6T    6)   �� *	frequence+6T   5(      5*      �� 5+      $��1��6   $
��10,5q�6"   $"��Слить в словарь��61   ��6K   �� *MergeDictionariesCommand+5,      �� 5-   
   $��1��6   $��5��6'   $��Center=�61   $��Stretch=�6N   � 5.   
   $��2��6    5/      �� 50      $
��auto �6    �� 51      $��* �6    .+�53      �� $��0��6   $
��10,5q�6"   $;��5Открыть новый текстовый файл��61   ��6X   �� *OpenFileCommand+�� 54      $��1��6   $��Disabled=�6I   ��6#   �� *WordsFromText+��55      �� 56      .R�57      � 58      ��5:      �� 5;       �� DataType$ textParser:Node��6#   .R�5<      ��    wButton#��[  5@   !   ��5<   !   �� *word+ �� UpdateSourceTrigger$ 	LostFocus=� � ToolTip 6Y   �� *tag+��5=   !   �� 	 ��  �� AncestorType$ ListBoxL� �� Path$' !DataContext.EditNodeInTextCommand���5?   !   �� 5@   !   5A      ��5C      �� 5D      " ��6   .�5E      ��  � ��$	 2,0q�63   �� 5F       � ��$ 0q�64   �� 5G       � ��$ 0q�6<   �� 5H       � ��
 ���� 67   5I      5K      5L      5M      5N      