import { Component } from '@angular/core';
import { MessageService } from 'primeng/api';
import { QuestionPaper } from 'src/Interfaces/QuestionPaper';

@Component({
  selector: 'app-faculty-main',
  templateUrl: './faculty-main.component.html',
  styleUrls: ['./faculty-main.component.css'],
})
export class FacultyMainComponent {

  questionPapers: QuestionPaper[] = [{name: 'Java', branch: [1,2], sectionsSelected: [1,2], multipleSections: true, sections: [''],immediateResult:false,bulitInKey:false,isTimeBound:false,testDuration:''}];

  questionPaper!:QuestionPaper;

  questionPaperName: string = '';
  branches: { label: string, value: number }[] = [{ label: 'ALL', value: 1 },{ label: 'CSE', value: 2 },{ label: 'ECE', value: 3 }];
  branchesSelected:number[] = [];
  sectionsInBranch: { label: string, value: number }[] = [{ label: 'ALL', value: 1 },{ label: 'A', value: 2 },{ label: 'B', value: 3 }];
  sectionsSelected:number[] = [];
  testDuration:any = '00:00';


  multipleSections: { label: string, value: boolean }[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];
  isContainsMultipleSections: { label: string, value: boolean } = { label: 'No', value: false };
  sectionsInQuestionPaper: { id: number, name: string }[] = [];
  clonedSections: { id: number, name: string }[] = [];
  sectionName: string = '';
  sectionLatestId: number = 0;

  builtInKeyOptions: { label: string, value: boolean }[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];
  builtInKey: { label: string, value: boolean } = { label: 'No', value: false };

  immediateResultOptions: { label: string, value: boolean }[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];
  immediateResult: { label: string, value: boolean } = { label: 'No', value: false };

  questionPaperNameInvalid: boolean = false;
  sectionNameEmpty:boolean = false;

  testDurationInvalid:boolean = false;

  timeBoundValues:{label:string,value:boolean}[] = [{label:'Yes',value:true},{label:'No',value:false}];
  isTimeBound:boolean = false;


  constructor(private messageService:MessageService) { }

  onAddSection() {
    this.sectionName  = this.sectionName.trim();
    if(this.sectionName !== '') {
    this.sectionLatestId += 1;
    this.sectionsInQuestionPaper.push({ id: this.sectionLatestId, name: this.sectionName });
    this.clonedSections.push({ id: this.sectionLatestId, name: this.sectionName });
    this.sectionName = '';
    this.sectionNameEmpty = false;
    } else {
      this.sectionNameEmpty = true;
    }
  }

  onEditCancel(index: number) {
    this.sectionsInQuestionPaper.at(index)!.name = this.clonedSections.at(index)!.name;
  }

  onEditSave(index: number) {
    this.clonedSections.at(index)!.name = this.sectionsInQuestionPaper.at(index)!.name;
  }

  onDeleteSection(index: number) {
    this.sectionsInQuestionPaper.splice(index, 1);
    this.clonedSections.splice(index, 1);
  }

  onReset() {
    this.questionPaperName = '';
    this.isContainsMultipleSections = { label: 'No', value: false };
    this.builtInKey = { label: 'No', value: false };
    this.sectionsInQuestionPaper = [];
    this.clonedSections = [];
    this.sectionName = '';
    this.sectionLatestId = 0;
    this.immediateResult = { label: 'No', value: false };
    this.questionPaperNameInvalid = false;
    this.sectionNameEmpty = false;
    this.branchesSelected = [];
    this.sectionsSelected = [];
    this.isTimeBound = false;
    this.testDurationInvalid = false;
    this.testDuration = '00:00';
  }

  onCreate() {
    if (this.validateQuestionPaper()) {
      var questionPaper: QuestionPaper = {
        name: this.questionPaperName,
        branch: this.branchesSelected,
        sectionsSelected: this.sectionsSelected,
        multipleSections: this.isContainsMultipleSections.value,
        sections: this.sectionsInQuestionPaper.map((ele) => {
          return ele.name
        }),
        bulitInKey: this.builtInKey.value,
        immediateResult: this.immediateResult.value,
        isTimeBound: this.isTimeBound,
        testDuration: typeof(this.testDuration) === 'string' ? '00:00' : (new Date(this.testDuration).getHours()+":"+new Date(this.testDuration).getMinutes())
      }
      this.messageService.add({
        severity: "success",
        detail: "Question paper created successfully"
      })
      this.questionPapers.push(questionPaper);
      console.log(questionPaper)
      this.onReset();
    }
  }

  validateQuestionPaper(): boolean {
    console.log(new Date(this.testDuration).getHours(),new Date(this.testDuration).getMinutes())
    var isValid: boolean = true;
    this.questionPaperName = this.questionPaperName.trim();
    if (this.questionPaperName === '') {
      this.questionPaperNameInvalid = true;
      isValid = false;
    } else {
      this.questionPaperNameInvalid = false;
    }

    if(this.isTimeBound) {
      if(this.testDuration === undefined) {
        this.testDurationInvalid = true;
        isValid = false;
      } else {
        this.testDurationInvalid = false;
      }
    } else {
      this.testDuration = '00:00';
      this.testDurationInvalid = false;
    }
    return isValid;
  }

  onEditPaperSettings(questionPaper:QuestionPaper) {
    this.questionPaper = questionPaper;
  }

}
