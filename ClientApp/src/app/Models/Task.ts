export interface Task {
    taskId :number;
    subject: string;
    createTime: Date ;
    startDate: Date ;
    dueDate: Date ;
    completedDate: Date ;
    complete: boolean;
    importance: string;

   
}

// taskId : parseInt(row_obj.TaskId),
// subject: row_obj.Subject,
// createTime: row_obj.CreateTime ,
// startDate: row_obj.StartDate ,
// dueDate: row_obj.DueDate ,
// completedDate: row_obj.CompletedDate ,
// complete: Boolean(JSON.parse(row_obj.Complete)),
// importance: row_obj.Importance,
