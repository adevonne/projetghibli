   M S B A M L   `   `   `  ����   ProjetGhibli1    +ProjetGhibliTicketApp.AdminTicketViewWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Gestion des Tickets��$	��450��$	��900��.��� $��10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��Deconnexion��$��0��$��Right=�$	��100��$��30��$��0,0,0,10q��� $��1��$	��Top=�$��0,0,0,10q�.+���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��SearchTextBox��$	��180��$��30��$��Center=��� -   $��SearchButton��$��
Rechercher��$��90��$��30��$��10,0,0,0q��� -   $��btnCreationTicket��$��Creation Ticket��$	��150��$��30��$
��Left=�$��0,10,0,0q�&   System.Windows.Controls.DataGrid  -     Name$ TicketsDataGrid��$��2��   AutoGenerateColumns$ False��   CanUserAddRows$ False��   
IsReadOnly$
 True��$��0,10,0,0q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *
IdTicket+  $ 
Nom Ticket��$	 * 
 �� *	NomTicket+  $ Demande��$	 * 
 �� *	Demande+  $ Date Creation��$
	 Auto 
 �� *DateCreation+  $ Nom Utilisateur��$
	 Auto 
 �� *NomUtilisateur+  $ 
Technicien��$
	 Auto 
 �� *
Technicien+  $ 	Categorie��$
	 Auto 
 �� *	Categorie+  $ Service��$
	 Auto 
 �� *	Service+  $ Statut��$
	 Auto 
 �� *Statut+  $ Priorite��$
	 Auto 
 �� *
Priorite+