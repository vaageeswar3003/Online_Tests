export interface Question {
    questionType: number,
    sectionId: number,
    question: string,
    answerType: number,
    negativeMarking: boolean,
    options: string[],
    correctAnswer: string,
    marks: number,
    negativeMarks: number
}