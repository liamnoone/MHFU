   M S B A M L   `   `   `  ����  MHFU    MHFU.wMonster   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Monsters��5   	    � Icon$" images/items/White Scale.png��6   $	��600��6>   $	��900��6K   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   .+�5
   
   �� $��0��6   $��4,0,4,4q�6#   $��Monsters��64   .��5      �  � RowDefinitions 5      �� 5      $��2* �6$   �� 5      $��8* �6$   .+�5      �� -   5        $��bImage��5   >   $��0��5      $��4,5,4,4q�6&   
���OO/�$	��1.5q�5      $��Center=�6/    �� CornerRadius$ 2��5      $y�Hidden=�6*   ._�5      �� -   5        $��imgIcon��5      $��5q�6_   ��6+   ��  	  Image �� 	Converter# [  6_   5      ]� 5      $��1��6   .+�5      �� -   5        $��stpSize��5   6   $	��Top=�6!    �� Orientation$ 
Horizontal=�6E   $
��0,10q�6^   $��Center=�6l   ��5      �� 5       �� 
TargetType" ��6$    �� Triggers 5   "   �� 5   &   	 �� Binding	 62   �� 
 �� ElementName$
 
dgMonsters�� �� Path$ SelectedItem.Min_Length� �� Value 5   2   Z� .a�5   *   ��  �� Property � y� �� Value$ Hidden=�6G   5   '   5       .+�5"      �� $��20��6    $$��images/monsters/Mini Crown.png��6+   �� 5#       �� Padding$
 10,0q�6$   ��63   �� $
 
dgMonsters��$ SelectedItem.Min_Length��� 5$      $ 0,0,10,0q�6$   ~6:   �� 5%      $��20��6    $$��images/monsters/King Crown.png��6+   �� 5&      $
 10,0q�6$   ��63   �� $
 
dgMonsters��$ SelectedItem.Max_Length�5'      �� 5(      -   5        $��	txtRefine��5(      $	��Top=�6/   $	��0,4q�6D   &   System.Windows.Controls.DataGrid  5)      -   5        $��
dgMonsters��5)      $��1��61   ��6>   ��    Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ #��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *ID+4  .System.Windows.Controls.DataGridTemplateColumn  5,         Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 65     MonsterIcon   CellTemplate# [ 6@     5-      $ Monster��61    
 Header   HeaderStyle# [ 6[    6B   �� *Name+6[   5/      50      51      52      � 53   
   $��1��6    54      �� 55      $��* �6    �� 56      $��* �6    �� 57      $��* �6    .+�59      �� $��0��6   $	��4,0q�6$   $��Low Rank��61   .��5:        -   5        $��	dgLowRank��5:      $��0��6,   $��3q�69   ��6D   ��  5;        5<      $ 25 61     
ItemColumn# [ 6<     5=      $
 Item��6-      
FontWeight$
 Bold"�6Z   # [ 6l    6;   �� *
Item1.Name+6l     5>      $	 Qty��6-    6:   �� *
Quantity+  5?      $
 Rate��6-    6;   �� *Rate+ �� StringFormat$
 {0}%��  5@      $ Source��6-    6=   �� *Source+5B      5C      �� 5D      $��1��6   $	��4,0q�6$   $��	High Rank��61   .��5E        -   5        $��
dgHighRank��5E      $��1��6-   $��3q�6:   ��6E   ��  5F        5G      $ 25 61   # [ 6<     5H      $
 Item��6-   $
 Bold"�6Z   # [ 6l    6;   �� *
Item1.Name+6l     5I      $	 Qty��6-    6:   �� *
Quantity+  5J      $
 Rate��6-    6;   �� *Rate+$
 {0}%��  5K      $ Source��6-    6=   �� *Source+5M      5N      �� 5O      $��2��6   $��4,0,4,4q�6$   $��G Rank��65   .��5P        -   5        $��dgGRank��5P      $��2��6*   $��3q�67   ��6B   ��  5Q        5R      $ 25 61   # [ 6<     5S      $
 Item��6-   $
 Bold"�6Z   # [ 6l    6;   �� *
Item1.Name+6l     5T      $	 Qty��6-    6:   �� *
Quantity+  5U      $
 Rate��6-    6;   �� *Rate+$
 {0}%��  5V      $ Source��6-    6=   �� *Source+5X      5Y      5Z      5[      5\      