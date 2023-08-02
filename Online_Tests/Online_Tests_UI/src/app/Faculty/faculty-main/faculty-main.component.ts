import { Component } from '@angular/core';
import { MessageService } from 'primeng/api';
import { lastValueFrom } from 'rxjs';
import { Branch } from 'src/Interfaces/Branch';
import { BranchesAndSectionsForExam } from 'src/Interfaces/BranchesAndSectionsForExam';
import { QuestionPaper } from 'src/Interfaces/QuestionPaper';
import { QuestionPaperSection } from 'src/Interfaces/QuestionPaperSection';
import { Section } from 'src/Interfaces/Section';
import { InstitutionService } from 'src/app/services/institution.service';
import { QuestionPaperService } from 'src/app/services/question-paper.service';

@Component({
  selector: 'app-faculty-main',
  templateUrl: './faculty-main.component.html',
  styleUrls: ['./faculty-main.component.css'],
})
export class FacultyMainComponent {

  questionPapers: QuestionPaper[] = [];
  questionPaper: QuestionPaper = { questionPaperName: '', builtInKey: false, immediateResult: false, institutionId: 0, isTimeBound: false, multipleSections: false, testDuration: '' };

  branches: Branch[] = [];
  branchSelected!: number;
  sections: Section[] = [];
  sectionsInBranch: Section[] = [];
  sectionsSelectedInBranch: number[] = [];
  branchesAndSectionsForExam: {branch: number, info:{section: number,id?:number}[]}[] = [];

  multipleSections: { label: string, value: boolean }[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];
  builtInKeyOptions: { label: string, value: boolean }[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];
  immediateResultOptions: { label: string, value: boolean }[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];
  timeBoundValues: { label: string, value: boolean }[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];

  sectionsInQuestionPaper: QuestionPaperSection[] = [];
  clonedSections: QuestionPaperSection[] = [];
  sectionName: string = '';
  sectionLatestId: number = 0;



  questionPaperNameInvalid: boolean = false;
  testDurationInvalid: boolean = false;
  sectionNameEmpty: boolean = false;
  updateMode: boolean = false;

  tabIndex: number = 0;

  constructor(private messageService: MessageService,
              private questionPaperService: QuestionPaperService,
              private institutionService:InstitutionService) {
    this.questionPaperService.getAllQuestionPapers().subscribe((questionPapers: QuestionPaper[]) => {
      this.questionPapers = questionPapers;
    });
    this.getBranchesAndSections();
  }

  getBranchesAndSections() {
    this.institutionService.getAllBranches(1).subscribe((branches) => {
      this.branches = branches;
      this.branches.map((branch) => {
        this.institutionService.getAllSections(branch.branchId).subscribe((sections) => {
          this.sections = this.sections.concat(sections);
        })
      });
      this.institutionService.getAllSections(branches[0].branchId).subscribe((sectionsInBranch) => {
        this.sectionsInBranch = [...sectionsInBranch];
      })
    })
  }

  onAddSection() {
    this.sectionName = this.sectionName.trim();
    if (this.sectionName !== '') {
      this.sectionLatestId += 1;
      this.sectionsInQuestionPaper.push({ id: this.sectionLatestId, questionPaperSectionName: this.sectionName });
      this.clonedSections.push({ id: this.sectionLatestId, questionPaperSectionName: this.sectionName });
      if(this.updateMode) {
        this.questionPaperService.createQuestionPaperSection({questionPaperSectionName:this.sectionName,questionPaperId:this.questionPaper.questionPaperId}).subscribe();
      }
      this.sectionName = '';
      this.sectionNameEmpty = false;
    } else {
      this.sectionNameEmpty = true;
    }
  }

  onBranchSelected() {
    this.institutionService.getAllSections(this.branchSelected).subscribe((sections) => {
      this.sectionsInBranch = [...sections];
    })
  }

  onAddBranchAndSection() {
    var branchAndSectionsForExam:{branch:number, info:{section:number,id?:number}[]} = {branch:this.branchSelected,info:[]};
      this.sectionsSelectedInBranch.map((section) => {
        var sectionAndId:{id?: number, section: number} = {section: section};
        branchAndSectionsForExam.info.push(sectionAndId);
      })
    if(this.updateMode) {
      branchAndSectionsForExam.info.map(data => {
        var branchAndSection:BranchesAndSectionsForExam = {
          branchId: branchAndSectionsForExam.branch,
          sectionId: data.section,
          questionPaperId: this.questionPaper.questionPaperId!
        }
        this.questionPaperService.createBranchAndSectionForExam(branchAndSection).subscribe();
      })
    } else {
    }
    this.branchesAndSectionsForExam = this.branchesAndSectionsForExam.concat(branchAndSectionsForExam);
    this.sectionsSelectedInBranch = [];
  }

  getBranchName(branchId:number) {
    return this.branches.at(branchId-1)?.branchName;
  }

  getSectionName(sectionId:number) {
    var sectionName;
    for(let section of this.sections) {
      if(section.sectionId === sectionId) {
        sectionName = section.sectionName;
        break;
      }
    }
    return sectionName;
  }

 async onDeleteBranchAndSections(index:number) {
    if(this.updateMode) {
      for (var data of this.branchesAndSectionsForExam.at(index)?.info!) {
          var branchAndSections:BranchesAndSectionsForExam = {
            id: data.id,
            questionPaperId: this.questionPaper.questionPaperId!,
            branchId: this.branchesAndSectionsForExam.at(index)?.branch!,
            sectionId: data.section!
          }
          await lastValueFrom(this.questionPaperService.deleteBranchAndSectionForExam(branchAndSections));
        }
    }
    this.branchesAndSectionsForExam.splice(index,1);
  }

  onEditCancel(index: number) {
    this.sectionsInQuestionPaper.at(index)!.questionPaperSectionName = this.clonedSections.at(index)!.questionPaperSectionName;
  }

  onEditSave(index: number) {
    this.clonedSections.at(index)!.questionPaperSectionName = this.sectionsInQuestionPaper.at(index)!.questionPaperSectionName;
  }

  onDeleteSection(index: number) {
    if(this.updateMode) {
      this.questionPaperService.deleteQuestionPaperSection(this.sectionsInQuestionPaper.at(index)!).subscribe();
    }
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
    this.sections = [];
    this.sectionsSelectedInBranch = [];
    this.testDurationInvalid = false;
    this.updateMode = false;
    this.questionPaper.testDuration = '00:00';
    this.branchesAndSectionsForExam = [];
    this.branchSelected = 1;
    this.sectionsInBranch = [];
    this.onBranchSelected();
    this.getBranchesAndSections();
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
          var { questionPaperSectionName } = ele;
          this.questionPaperService.createQuestionPaperSection({ questionPaperSectionName, questionPaperId:newQuestionPaper.questionPaperId! }).subscribe();
        })
        this.branchesAndSectionsForExam.map(branches => {
          branches.info.map(data => {
            var branchAndSection: BranchesAndSectionsForExam = {branchId: branches.branch, sectionId: data.section, questionPaperId: newQuestionPaper.questionPaperId!};
            this.questionPaperService.createBranchAndSectionForExam(branchAndSection).subscribe();
          })
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
    this.questionPaperService.getAllQuestionPaperSectionsByQuestionPaperId(questionPaper.questionPaperId!).subscribe((data) => {
      this.sectionsInQuestionPaper = [...data];
      this.clonedSections  = [...data];
      this.sectionLatestId = this.sectionsInQuestionPaper.at(this.sectionsInQuestionPaper.length-1)?.id!;
    })
    this.questionPaperService.getAllBranchesAndSectionsForExamByQuestionPaperId(questionPaper.questionPaperId!).subscribe((data) => {
      var branches:Map<number,number> = new Map<number, number>();
      var index = 0;
      data.map((ele) => {
        if(!branches.has(ele.branchId)) {
          var branchAndSections:{branch: number, info:{section: number,id?:number}[]} = {branch:ele.branchId, info:[{section: ele.sectionId,id:ele.id!}]};
          this.branchesAndSectionsForExam.push(branchAndSections);
          branches.set(ele.branchId, index);
          index++;
        } else {
          var sectionAndId:{id?:number, section:number} = {id: ele.id, section: ele.sectionId};
          this.branchesAndSectionsForExam.at(branches.get(ele.branchId)!)?.info.push(sectionAndId);
        }
      })
    });
    this.questionPaper = questionPaper;
    this.updateMode = true;
    this.tabIndex = 1;
  }

  async onUpdate() {
    if (this.questionPaper.isTimeBound) {
      this.questionPaper.testDuration = this.convertTestDurationToString();
    } else {
      this.questionPaper.testDuration = "00:00";
    }
    this.updateMode = false;
    for await(var section of this.sectionsInQuestionPaper) {
      this.questionPaperService.updateQuestionPaperSection(section).subscribe();
    }
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
