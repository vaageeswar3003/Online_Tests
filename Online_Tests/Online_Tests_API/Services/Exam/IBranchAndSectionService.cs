﻿using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Exam
{
    public interface IBranchAndSectionService
    {
        Task<BranchesAndSectionsForTestEntity> CreateBranchAndSection(BranchesAndSectionsForTestEntity branchAndSection);
        Task<BranchesAndSectionsForTestEntity> DeleteBranchAndSection(BranchesAndSectionsForTestEntity branchAndSection);
        Task<IEnumerable<BranchesAndSectionsForTestEntity>> GetAllBranchesAndSectionsByQuestionPaperId(int questionPaperId);
        Task<BranchesAndSectionsForTestEntity> UpdateBranchAndSection(BranchesAndSectionsForTestEntity branchAndSection);
    }
}