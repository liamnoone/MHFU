   M S B A M L   `   `   `  ����?  ;MHFU, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MHFUMHFU  5          MHFU.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5       cclr-namespace:MHFU     5        �� ShutdownMode$  OnMainWindowClose=�5       �� 	Resources 5         MHFU.ImageConvertor 	  Image   MHFU.PriceConvertor 	 Price   MHFU.TradeConvertor  TradeConvertor �� 
TargetType �� Property �� Value 
 Search&   System.Windows.Controls.DataGrid)  #System.Windows.Controls.DataGridRow �� Triggers �� Binding �� Value P� Property	 P� Value*  $System.Windows.Controls.DataGridCell 
 Rarity  
Percentage 
 Header=  7System.Windows.Controls.Primitives.DataGridColumnHeader  EmphasizedColumn  
ItemColumn
 �� 	Converter �� ConverterParameter 	 Combo1Column 
 Combo2Column  ComboRColumn  
AreaColumn  Buy �� Padding  Sell  MonsterIcon  Monster 	 Trade  CommonTrade  	RareTrade  TradeLocation  Alchemy��%R  &	        &	      &	 &     '� 9     &	 �     '      '      '�� �    '�� �    '9� &    &	 �    &	 �	    &	 N    &	 �    '  �    &	 ;    7   &		 �    7   &	
 �    7   &	 =    7   &	 �    7   &	 �    7  &	 h    7  &	 �    7   &	 &    7   &	 G    7   &	 �    7   &	 �    7   &	     7   &	 f      5	   
   6     5
   
   6     5   
   6   �� 5   
   " �6   .�5      ��  � ��$ Calibri)�6,   �� 5       � ��$ 13(�6*   5      �� 5   
   " ��6   .�5      ��  � ��$ 25��6'   �� 5       � ��$ Center=�69   5      �� 5   
   "  6   .�5      ��  �@ AutoGenerateColumns .  64   �� 5       �@ 
IsReadOnly . 6+   �� 5        �@ HorizontalGridLinesBrush
 �����69   �� 5       �@ VerticalGridLinesBrush
 �����67   �� 5       � ��$ Center=�6;   �� 5       �@ SelectionUnit$ FullRow=�6.   �� 5       � |� .  6*   �� 5      # �@ VerticalScrollBarVisibility$
 Auto=�6<   �� 5        � ��
 ���� 6+   5!      �� 5#   
   "  6    5$      �� 5%       6   ��  62   Z� .a�5&      ��  � ��
 �   �63   5'      5)      �� 5+   
   " ��6   .�5,      ��  � ��$
 Bold"�6+   5-      �� 5/   
   " ��6   .�50      ��  � ��$ Normal"�6+   51      �� 53   
   " 9�6   .�54      ��  �@9�ExpandDirection$
 Down=�60   �� 55       �@9�
IsExpanded .  6+   �� 56       � ��
 �OO/�6,   �� 57       � ��$ 0,2,0,4q�6'   �� 58       � ��$ 5,4,2,3q�6(   -   5         5?      P� 5@       �@9�
IsExpanded	 . . �5A      ��  � ��$ 5,4,5,5q�60   �� 5B       � ��$ 0,2,0,4q�6/   5D      5F      �� 5H   
   "  6    5I      �� 5J       6   �� *Rarity+ 1069   .a�5K      ��  � ��
 �� ��63   �� 5L       � ��$ Black"�63   5M      �� 5N       6   �� *Rarity+ 969   .a�5O      ��  � ��
 � ���63   �� 5P       � ��$ Black"�63   5Q      �� 5R       6   �� *Rarity+ 869   .a�5S      ��  � ��
 �  ��63   �� 5T       � ��$ Black"�63   5U      �� 5V       6   �� *Rarity+ 769   .a�5W      ��  � ��
 � ���63   �� 5X       � ��$ Black"�63   5Y      �� 5Z       6   �� *Rarity+ 669   .a�5[      ��  � ��
 ��� �63   �� 5\       � ��$ Black"�63   5]      �� 5^       6   �� *Rarity+ 569   .a�5_      ��  � ��
 �����63   �� 5`       � ��$ Black"�63   5a      �� 5b       6   �� *Rarity+ 469   .a�5c      ��  � ��
 �2�2�63   �� 5d       � ��$ Black"�63   5e      5g      �� 5i   
   "  6   .�5j      ��  � ��$ Center=�6;   �� 5k       � ��$ Center=�69   �� 5l       � ��
 ���� 6,    5n      �� 5o       6   �� *	Success+ 1006:   .a�5p      ��  � ��
 � d �63   �� 5q       � ��$ Black"�63   5r      �� 5t       6   �� *	Success+ 956:   .a�5u      ��  � ��
 � � �63   �� 5v       � ��$ Black"�63   5w      �� 5y       6   �� *	Success+ 906:   .a�5z      ��  � ��
 ����63   �� 5{       � ��$ Black"�63   5|      �� 5~       6   �� *	Success+ 856:   .a�5      ��  � ��
 � ���63   �� 5�       � ��$ Black"�63   5�      �� 5�       6   �� *	Success+ 756:   .a�5�      ��  � ��
 � ���63   �� 5�       � ��$ Black"�63   5�      �� 5�       6   �� *	Success+ 656:   .a�5�      ��  � ��
 � E��63   �� 5�       � ��$ Black"�63   5�      �� 5�       6   �� *	Success+ 556:   .a�5�      ��  � �� �#F0000063   �� 5�       � ��$ 
ExtraBlack"�63   5�      5�      �� 5�   
   "  6   .�5�      ��  � ��$ SemiBold"�6+   5�      �� 5�   
   "  6   .�5�      ��  � ��$ DemiBold"�6+   5�      �� 5�   
   "  6   .�5�      ��  � ��$ Center=�6;   6L   5�      �� 5�   
   .R�5�      �� $��22��6   ��6   �� 8
   $
 Item��5�      �� 5�   
   .R�5�      �� $��22��6   ��6   �� 8
   $ Combo 1��5�      �� 5�   
   .R�5�      �� $��22��6   ��6   �� 8
   $ Combo 2��5�      �� 5�   
   .R�5�      �� $��22��6   ��6   �� 8
   $ Combo Result��5�      �� 5�   
   .R�5�      �� $��22��6   ��6   �� 8
   $ Location��5�      �� 5�   
   .R�5�      �� $��Center=�5�      $	 5,0q�65   ��5�      �� 8
   $	 Buy��5�   5   5�      �� 5�   
   .R�5�      �� $��Center=�5�      $	 5,0q�65   ��5�      �� 8
   $
 Sell��5�   5   5�      �� 5�   
   .R�5�      �� ��6   �� 8
   $
 Icon��5�      �� 5�   
   ��6    �� 8
   �� 5�   
   .R�5�      �� ��6   �� 8
   $ Trade��5�      �� 5�   
   .R�5�      �� ��6   �� 8
   $ Common��5�      �� 5�   
   .R�5�      �� ��6   �� 8
   $
 Rare��5�      �� 5�   
   .R�5�      �� ��6   �� 8
   $ Location��5�      �� 5�   
   "  6    5�      �� 5�       6   �� *	Alchemy+ True6:   .a�5�      ��  � ��
 �  ��63   5�      5�      5�      5�      