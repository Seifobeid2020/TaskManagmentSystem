import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TasksCategoriesComponent } from './tasks-categories.component';

describe('TasksCategoriesComponent', () => {
  let component: TasksCategoriesComponent;
  let fixture: ComponentFixture<TasksCategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TasksCategoriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TasksCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
