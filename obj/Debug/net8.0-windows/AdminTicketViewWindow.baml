   M S B A M L   `   `   `  ����  ProjetGhibli1    +ProjetGhibliTicketApp.AdminTicketViewWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Gestion des Tickets��5   	   $	��450��6%   $	��900��62   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��Deconnexion��5      $��0��5      $��Right=�5      $	��100��5      $��30��6   $��0,0,0,10q�5      �� 5   
   $��1��6   $	��Top=�5      $��0,0,0,10q�5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� -   5        $��SearchTextBox��5      $	��180��6/   $��30��6;   $��Center=�6G   �� 5      -   5        $��SearchButton��5   .   $��
Rechercher��6   $��90��6B   $��30��6M   $��10,0,0,0q�6Y   6k   5       �� 5#      -   5        $��btnCreationTicket��5$      $��Creation Ticket��5#      $	��150��5&      $��30��6!   $
��Left=�5'      $��0,10,0,0q�5(      5)      &   System.Windows.Controls.DataGrid  5,   
   -   5          Name$ TicketsDataGrid��5,      $��2��5-         AutoGenerateColumns$ False��5.         CanUserAddRows$ False��5/         
IsReadOnly$
 True��50      $��0,10,0,0q�51         Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6N   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *
IdTicket+6N     54      $ 
Nom Ticket��6%   $	 * 6W   
 69   �� *	NomTicket+6W     55      $ Demande��6%   $	 * 6R   
 66   �� *	Demande+6R     56      $ Date Creation��6%   $
	 Auto 6]   
 6<   �� *DateCreation+6]     57      $ Nom Utilisateur��6%   $
	 Auto 6a   
 6>   �� *NomUtilisateur+6a     58      $ 
Technicien��6%   $
	 Auto 6X   
 69   �� *
Technicien+6X     59      $ 	Categorie��6%   $
	 Auto 6V   
 68   �� *	Categorie+6V     5:      $ Service��6%   $
	 Auto 6R   
 66   �� *	Service+6R     5;      $ Statut��6%   $
	 Auto 6P   
 65   �� *Statut+6P     5<      $ Priorite��6%   $
	 Auto 6T   
 67   �� *
Priorite+6T   5>      5?      5@      