using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

namespace IsmaelNascimento {  
    public class SliderManager: MonoBehaviour {  
        #region VARIABLES[SerializeField] private Button btnBack;  
        //Creating the buttons to display images utilizing serialized fields
        //when button is clicked next it will play the slide that goes next if there is nothing at the end it will go back to beginning
        //when back button is clicked it will move backwards in the list if at the front will rotate to the back
        [SerializeField] private Image imgShow;  
        [SerializeField] private Button btnNext;  
        [SerializeField] private Button btnBack;  
        [Space(10)]  
        [SerializeField] private List < Sprite > imagesForShow;  
        private int indexImagesForShow;  
        #endregion  
        #region METHODS_MONOBEHAVIOUR  
        private void Start() {  
            btnBack.onClick.AddListener(OnButtonBackClicked);  
            btnNext.onClick.AddListener(OnButtonNextClicked);  
        }  
        #endregion  
        #region METHODS_PRIVATE  
        private void OnButtonBackClicked() {  
            indexImagesForShow--;  
            if (indexImagesForShow < 0) {  
                indexImagesForShow = imagesForShow.Count - 1;  
            }  
            imgShow.sprite = imagesForShow[indexImagesForShow];  
        }  
        private void OnButtonNextClicked() {  
            indexImagesForShow++;  
            if (indexImagesForShow > imagesForShow.Count - 1) {  
                indexImagesForShow = 0;  
            }  
            imgShow.sprite = imagesForShow[indexImagesForShow];  
        }  
        #endregion  
    }  
}  
