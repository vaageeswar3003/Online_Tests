import { Component } from '@angular/core';
import { MessageService } from 'primeng/api';
import { map } from 'rxjs';
import { QuestionPaper } from 'src/Interfaces/QuestionPaper';
import { QuestionPaperSection } from 'src/Interfaces/QuestionPaperSection';
import { QuestionPaperService } from 'src/app/services/question-paper.service';

@Component({
  selector: 'app-faculty-main',
  templateUrl: './faculty-main.component.html',
  styleUrls: ['./faculty-main.component.css'],
})
export class FacultyMainComponent {

  questionPapers: QuestionPaper[] = [];
  questionPaper: QuestionPaper = { questionPaperName: '', builtInKey: false, immediateResult: false, institutionId: 0, isTimeBound: false, multipleSections: false, testDuration: '' };

  branches: { label: string, value: number }[] = [{ label: 'ALL', value: 1 }, { label: 'CSE', value: 2 }, { label: 'ECE', value: 3 }];
  branchesSelected: number[] = [];
  sectionsInBranch: { label: string, value: number }[] = [{ label: 'ALL', value: 1 }, { label: 'A', value: 2 }, { label: 'B', value: 3 }];
  sectionsSelected: number[] = [];

  multipleSections: { label: string, value: boolean }[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];
  builtInKeyOptions: { label: string, value: boolean }[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];
  immediateResultOptions: { label: string, value: boolean }[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];
  timeBoundValues: { label: string, value: boolean }[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];

  sectionsInQuestionPaper: { id: number, name: string }[] = [];
  clonedSections: { id: number, name: string }[] = [];
  sectionName: string = '';
  sectionLatestId: number = 0;



  questionPaperNameInvalid: boolean = false;
  testDurationInvalid: boolean = false;
  sectionNameEmpty: boolean = false;
  updateMode: boolean = false;

  tabIndex: number = 0;

  constructor(private messageService: MessageService, private questionPaperService: QuestionPaperService) {
    this.questionPaperService.getAllQuestionPapers().subscribe((questionPapers: QuestionPaper[]) => {
      this.questionPapers = questionPapers;
    })
  }

  onAddSection() {
    this.sectionName = this.sectionName.trim();
    if (this.sectionName !== '') {
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
    this.questionPaper = { questionPaperName: '', builtInKey: false, immediateResult: false, institutionId: 0, isTimeBound: false, multipleSections: false, testDuration: '' };
    this.sectionsInQuestionPaper = [];
    this.clonedSections = [];
    this.sectionName = '';
    this.sectionLatestId = 0;
    this.questionPaperNameInvalid = false;
    this.sectionNameEmpty = false;
    this.branchesSelected = [];
    this.sectionsSelected = [];
    this.testDurationInvalid = false;
    this.updateMode = false;
    this.questionPaper.testDuration = '00:00';
  }

  onCreate() {
    if (this.validateQuestionPaper()) {
      var questionPaper: QuestionPaper = {
        institutionId: 1,
        questionPaperName: this.questionPaper.questionPaperName,
        multipleSections: this.questionPaper.multipleSections,
        builtInKey: this.questionPaper.builtInKey,
        immediateResult: this.questionPaper.immediateResult,
        isTimeBound: this.questionPaper.isTimeBound,
        testDuration: typeof (this.questionPaper.testDuration) === 'string' ? '00:00' : this.convertTestDurationToString()
      }
      this.questionPaperService.createQuestionPaper(questionPaper).subscribe((newQuestionPaper: QuestionPaper) => {
        this.questionPapers = [...this.questionPapers, newQuestionPaper];
        this.sectionsInQuestionPaper.map((ele) => {
          var { name: questionPaperSectionName} = ele;
          this.questionPaperService.createQuestionPaperSection({ questionPaperSectionName, questionPaperId:newQuestionPaper.questionPaperId! }).subscribe();
        })
        this.messageService.add({
          severity: "success",
          detail: "Question paper created successfully"
        })
        this.onReset();
      });
    }
  }

  validateQuestionPaper(): boolean {
    var isValid: boolean = true;
    this.questionPaper.questionPaperName = this.questionPaper.questionPaperName.trim();
    if (this.questionPaper.questionPaperName === '') {
      this.questionPaperNameInvalid = true;
      isValid = false;
    } else {
      this.questionPaperNameInvalid = false;
    }

    if (this.questionPaper.isTimeBound) {
      if (this.questionPaper.testDuration === undefined) {
        this.testDurationInvalid = true;
        isValid = false;
      } else {
        this.testDurationInvalid = false;
      }
    } else {
      this.questionPaper.testDuration = '00:00';
      this.testDurationInvalid = false;
    }
    return isValid;
  }

  onEditPaperSettings(questionPaper: QuestionPaper) {
    this.questionPaper = questionPaper;
    this.updateMode = true;
    this.tabIndex = 1;
  }

  onUpdate() {
    if (this.questionPaper.isTimeBound) {
      this.questionPaper.testDuration = this.convertTestDurationToString();
    } else {
      this.questionPaper.testDuration = "00:00";
    }
    this.updateMode = false;
    this.questionPaperService.updateQuestionPaper(this.questionPaper).subscribe((data) => {
      this.messageService.add({
        severity: "success",
        detail: "Question paper Updated successfully"
      })
      this.onReset();
    })
  }

  onTabIndexChange(event: any) {
    this.tabIndex = event;
    if(event === 0) {
      this.onReset();
    }
  }

  onDeleteQuestionPaper(questionPaper: QuestionPaper, rowIndex: number) {
    return this.questionPaperService.deleteQuestionPaper(questionPaper).subscribe((data) => {
      this.messageService.add({
        severity: "success",
        detail: `Question paper deleted successfully`
      });
      this.questionPapers.splice(rowIndex, 1);
      this.questionPapers = [...this.questionPapers];
    });
  }

  convertTestDurationToString(): string {
    return (new Date(this.questionPaper.testDuration).getHours() + ":" + new Date(this.questionPaper.testDuration).getMinutes());
  }

}
