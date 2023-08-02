import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BranchesAndSectionsForExam } from "src/Interfaces/BranchesAndSectionsForExam";
import { QuestionPaper } from "src/Interfaces/QuestionPaper";
import { QuestionPaperSection } from "src/Interfaces/QuestionPaperSection";
import { environment } from "src/environments/environment";


@Injectable({
    providedIn: 'root'
})
export class QuestionPaperService {

    private readonly apiUrl = environment.apiUrl+'exam/';

    constructor(private http:HttpClient) { }

    // Question Paper API end point calls

    getAllQuestionPapers() {
        return this.http.get<QuestionPaper[]>(this.apiUrl+'get-all-question-papers');
    }

    createQuestionPaper(questionPaper:QuestionPaper) {
        return this.http.post<QuestionPaper>(this.apiUrl+'create-question-paper',questionPaper);
    }

    updateQuestionPaper(questionPaper:QuestionPaper) {
        return this.http.put<QuestionPaper>(this.apiUrl+'update-question-paper',questionPaper);
    }

    deleteQuestionPaper(questionPaper:QuestionPaper) {
        return this.http.delete<QuestionPaper>(this.apiUrl+'delete-question-paper',{body: questionPaper});
    }

    // Question Paper Sections API end point calls

    getAllQuestionPaperSections() {
        return this.http.get<QuestionPaperSection[]>(this.apiUrl+'get-all-question-paper-sections');
    }

    getAllQuestionPaperSectionsByQuestionPaperId(questionPaperId:number) {
        return this.http.get<QuestionPaperSection[]>(this.apiUrl+'get-all-question-paper-sections-by-question-paper-id?questionPaperId='+questionPaperId);
    }

    createQuestionPaperSection(questionPaperSection:QuestionPaperSection) {
        return this.http.post<QuestionPaperSection>(this.apiUrl+'create-question-paper-section',questionPaperSection);
    }

    updateQuestionPaperSection(questionPaperSection:QuestionPaperSection) {
        return this.http.put<QuestionPaperSection>(this.apiUrl+'update-question-paper-section',questionPaperSection);
    }

    deleteQuestionPaperSection(questionPaperSection:QuestionPaperSection) {
        return this.http.delete<QuestionPaperSection>(this.apiUrl+'delete-question-paper-section',{body: questionPaperSection});
    }
    
    // API Calls for branches and section for exam

    getAllBranchesAndSectionsForExamByQuestionPaperId(questionPaperId:number) {
        return this.http.get<BranchesAndSectionsForExam[]>(this.apiUrl+'get-all-branches-and-sections-by-question-papaer-id?questionPaperId='+questionPaperId);
    }

    createBranchAndSectionForExam(branchAndSection:BranchesAndSectionsForExam) {
        return this.http.post<BranchesAndSectionsForExam>(this.apiUrl+'create-branch-and-section',branchAndSection);
    }

    updateBranchAndSectionForExam(branchAndSection:BranchesAndSectionsForExam) {
        return this.http.put<BranchesAndSectionsForExam>(this.apiUrl+'update-branch-and-section',branchAndSection);
    }

    deleteBranchAndSectionForExam(branchAndSection:BranchesAndSectionsForExam) {
        return this.http.delete<BranchesAndSectionsForExam>(this.apiUrl+'delete-branch-and-section',{body: branchAndSection});
    }

}