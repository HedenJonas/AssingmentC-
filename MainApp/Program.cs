using Business.Interfaces;
using Business.Services;
using MainApp.MenuDialog;


IFileService fileService = new FileService();
var userService = new UserService(fileService);
var menu = new MenuDialog(userService);
menu.ShowMenu();