import { Component, ElementRef, Input, OnInit, QueryList,  ViewChildren } from '@angular/core';
import { ProjectService } from '../Service/projectService.service';
import { Contact } from '../Model/Contact'
import { SendMessageTo } from '../Model/SendMessageTo'
import { MessageDTO } from '../Model/DTOs/MessageDTO'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit{
  public contact: Contact =new Contact ();
  public allContacts: Contact[];
  public message: string='';
  public sendMessageTo: SendMessageTo[]=[];
  public newContact: SendMessageTo;
  @ViewChildren("checkboxes") checkboxes: QueryList<ElementRef>;
  public messageDTO: MessageDTO = new MessageDTO();

  constructor(private projectService: ProjectService) {
  }

  ngOnInit() {
    //get all users
    this.projectService.getAll().subscribe(
      (response) => {      
        this.allContacts = response;
      },
      () => { alert("Pogreška prilikom dohvaćanaj svih kontakata") }
    );
  }
  
  public saveContact(contact:Contact) {        
    //post contact data
    this.projectService.addNewContact(contact)
      .subscribe(
        (res) => {         
          contact = res;
         //add new contact to list of all contacts
          this.allContacts.push(contact);         
          alert("Kontakt uspješno dodan");         
        },
        () => { alert("Pogreška prilikom dodavanja novog kontakta") }
      );

    //clear contact object
    for (var variableKey in contact) {
      if (contact.hasOwnProperty(variableKey)) {
        delete contact[variableKey];
      }
    }
  }

  //on checkbox click add contact to list
  public addContactToMessageList(event,contact) {
    if (event.target.checked) {
      this.newContact = {} as SendMessageTo;
      this.newContact.ContactId = contact.contactId;
      this.newContact.Number = contact.number;    
      this.sendMessageTo.push(this.newContact);     
      return;
    }
    //on uncheck remove contact from list
    var index = this.sendMessageTo.indexOf(contact.contactId);
    this.sendMessageTo.splice(index, 1);    
  }

  public sendMessage() {
    //create messageDTO
    this.messageDTO.contacts = this.sendMessageTo;
    this.messageDTO.message = this.message;
   
    this.projectService.sendNewMessage(this.messageDTO)
      .subscribe(
         (res) => {
          alert("Poruka uspješno poslana");         
        },
        (error) => { alert("Pogreška prilikom slanja poruke") }
      );
    //clear sms textbox
    this.message = '';
   
    //remove checked checkboxes after sending message
    this.checkboxes.forEach((element) => {
      element.nativeElement.checked = false;
    });
  }
}
