export interface ILeave {
   // id: number;  
    leave_Type  : string;  
    emp_ID : number;  
    leave_From: Date;  
    leave_To : Date;  
    //isActive : boolean;  
    Applied_Date: Date;  
    manager_Id: number;
    isAccepted:boolean;
}
