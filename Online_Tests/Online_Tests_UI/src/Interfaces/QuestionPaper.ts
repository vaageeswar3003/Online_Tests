export interface QuestionPaper {
    questionPaperId?: number,
    questionPaperName:string,
    multipleSections: boolean,
    builtInKey: boolean,
    immediateResult: boolean,
    isTimeBound:boolean,
    testDuration: string,
    institutionId: number
}