import { Component, ViewChild } from '@angular/core';
import { FileUpload } from 'primeng/fileupload';
import { Question } from '../../Interfaces/Question'
import { MessageService } from 'primeng/api';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-question-paper-edit',
  templateUrl: './question-paper-edit.component.html',
  styleUrls: ['./question-paper-edit.component.css']
})
export class QuestionPaperEditComponent {

  questionTypes: { type: string, value: number }[] = [{ type: 'Text', value: 1 }, { type: 'Image', value: 2 }];
  questionType: { type: string, value: number } = { type: 'Text', value: 1 };

  options: { id: number, option: string }[] = [];
  clonedOptions: { id: number, option: string }[] = [];
  latestOptionId: number = 0;
  option: string = '';

  imageQuestion: any = null;
  correctAnswer: string = '';
  answerTypes: { type: string, value: number }[] = [{ type: 'Single Choice', value: 1 }, { type: 'Multiple Choice', value: 2 }, { type: 'Numerical or Text', value: 3 }];
  answerType: { type: string, value: number } = { type: 'Single Choice', value: 1 };
  textQuestion = '';
  isNegativeMarking: { label: string, value: boolean } = { label: 'No', value: false };
  negativeMarking: { label: string, value: boolean }[] = [{ label: 'Yes', value: true }, { label: 'No', value: false }];
  negativeMarks: number = 0;
  optionInvalid: boolean = false;
  questionInvalid: boolean = false;
  correctAnswerInvalid: boolean = false;
  imageQuestionInvalid: boolean = false;
  emptyOptions: boolean = false;
  marks: number = 0;
  // question:Question = {
  //   questionType: 1,
  //   question: '',
  //   answerType: 3,
  //   negativeMarking: false,
  //   correctAnswer: '',
  //   marks: 0,
  //   negativeMarks: 0,
  //   options: []
  // }

  @ViewChild('imageSelector') imageSelector !: FileUpload

  constructor(private messageService: MessageService, private route: ActivatedRoute) {
    console.log(route.snapshot.params['id']);
  }

  onOptionAdd() {
    if (this.emptyOptions) {
      this.emptyOptions = false;
    }
    if (this.option !== '') {
      this.latestOptionId += 1;
      this.options.push({ id: this.latestOptionId, option: this.option });
      this.clonedOptions.push({ id: this.latestOptionId, option: this.option });
      this.optionInvalid = false;
    } else {
      this.optionInvalid = true;
    }
    this.option = '';
  }

  onDeleteOption(ri: number) {
    this.options.splice(ri, 1);
    this.clonedOptions.splice(ri, 1);
  }

  onEditSave(rowIndex: number) {
    this.clonedOptions.at(rowIndex)!.option = this.options.at(rowIndex)!.option;
  }

  onEditCancel(rowIndex: number) {
    this.options.at(rowIndex)!.option = this.clonedOptions.at(rowIndex)!.option;
  }

  onQuestionImageSelected(event: any) {
    this.imageQuestion = event.currentFiles[0];
  }

  onDeleteSelectedImage() {
    this.imageQuestion = null;
    this.imageSelector.files = [];
  }

  onClear() {
    this.correctAnswer = '';
    this.questionType = { type: 'Text', value: 1 };
    this.answerType = { type: 'Single Choice', value: 1 };
    this.options = [];
    this.clonedOptions = [];
    this.textQuestion = '';
    this.isNegativeMarking = { label: 'No', value: false };
    this.negativeMarks = 0;
    this.optionInvalid = false;
    this.questionInvalid = false;
    this.correctAnswerInvalid = false;
    this.imageQuestionInvalid = false;
    this.emptyOptions = false;
    this.marks = 0;
    this.imageQuestion = null;
  }

  onCreate() {
    if (this.isQuestionFormValid()) {
      var questionData: string = '';
      var options: string[] = [];
      if (this.answerType.value !== 3) {
        options = [...options];
      }
      if (this.questionType.type === 'Image') {
        this.convertImageToBase64(this.imageQuestion).then((data) => {
          questionData = data;
          this.createQuestion(questionData, options);
        });
      } else {
        questionData = this.textQuestion;
        this.createQuestion(questionData, options);
      }
      this.messageService.add({ severity: 'success', detail: 'Question Created' });
      this.onClear();
    }
  }

  createQuestion(questionData: string, options: string[]) {
    var question: Question = {
      questionType: this.questionType.value,
      sectionId: -1,
      question: questionData,
      answerType: this.answerType.value,
      negativeMarking: this.isNegativeMarking.value,
      correctAnswer: this.correctAnswer,
      marks: this.marks,
      negativeMarks: this.negativeMarks,
      options: options
    }
  }

  convertImageToBase64(file: File): Promise<string> {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => resolve(reader.result as string);
      reader.onerror = reject;
    })
  }

  isQuestionFormValid(): boolean {
    var isValid = true;
    if (this.questionType.type === 'Text') {
      if (this.textQuestion === '') {
        this.questionInvalid = true;
        isValid = false;
      } else {
        this.questionInvalid = false;
      }
    } else {
      if (this.imageQuestion === null) {
        this.imageQuestionInvalid = true;
        isValid = false;
      } else {
        this.imageQuestionInvalid = false;
      }
    }
    if (this.correctAnswer === '') {
      this.correctAnswerInvalid = true;
      isValid = false;
    } else {
      this.correctAnswerInvalid = false;
    }

    if (this.answerType.value !== 3) {
      if (this.options.length === 0) {
        this.emptyOptions = true;
        isValid = false;
      } else {
        this.emptyOptions = false;
      }
    }
    return isValid;
  }


}
